using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Swashbuckle.AspNetCore.Filters;
using System.Text.Json;
using System.Text.Json.Serialization;
using WeatherDisplayService.Models.DataModels.OpenWeather;

namespace WeatherDisplayService.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class WeatherController : ControllerBase
{
    private const string BaseUrl = "https://api.openweathermap.org/data/3.0/onecall";

    private readonly IMemoryCache _cache;
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;
    private readonly ILogger<WeatherController> _logger;

    public WeatherController(IMemoryCache cache, IConfiguration configuration, HttpClient httpClient, ILogger<WeatherController> logger)
    {
        _cache = cache;
        _configuration = configuration;
        _httpClient = httpClient;
        _logger = logger;
    }

    /// <summary>
    /// Retrieves weather data by coordinates.
    /// </summary>
    /// <returns>Weather data for the specified coordinates.</returns>
    /// <response code="200">Returns the weather data</response>
    /// <response code="400">If the coordinates are invalid.</response>
    /// <response code="401">If the access token is invalid.</response>

    [HttpGet]    
    [SwaggerRequestExample(typeof(WeatherRequest), typeof(WeatherRequestExample))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WeatherResponse))]  
    [ProducesResponseType(StatusCodes.Status400BadRequest,Type= typeof(ErrorResponse))]
    [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(BadRequestExample))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    

    public async Task<IActionResult> GetWeather([FromQuery] WeatherRequest request)
    {
        string units = "standard";
        
        var cacheKey = $"Weather_{request.Latitude}_{request.Longitude}_{units}";
        if (_cache.TryGetValue(cacheKey, out WeatherResponse cachedWeatherData))
        {
            return Ok(cachedWeatherData);
        }

        string apiKey = _configuration["OpenWeatherMapApiKey"];
        string url = $"{BaseUrl}?lat={request.Latitude}&lon={request.Longitude}&units={units}&appid={apiKey}";

        HttpResponseMessage response = await _httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            try
            {
                var weatherData = JsonSerializer.Deserialize<WeatherResponse>(content, GetJsonSerializerOptions());
                if (weatherData != null)
                {
                    var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(10));
                    _cache.Set(cacheKey, weatherData, cacheEntryOptions);

                    return Ok(weatherData); 
                }
                else
                {
                    _logger.LogError("Failed to deserialize weather data");
                    return BadRequest("Error processing weather data");
                }

            }
            catch (JsonException ex)
            {

                _logger.LogError(ex, "Error in JSON conversion");
                var errorResponse = new ErrorResponse
                {
                    Error = StatusCodes.Status400BadRequest,
                    Message = "Error processing weather data"
                };
                return BadRequest(errorResponse);
            }            
        }

        return BadRequest("Error fetching weather data");
    }


    private JsonSerializerOptions GetJsonSerializerOptions()
    {
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,            
        };        

        return options;
    }

}


public class BadRequestExample : IExamplesProvider<ErrorResponse>
{
    public ErrorResponse GetExamples()
    {
        return new ErrorResponse
        {
            Message = "Invalid request parameters",
            Error = 400
        };
    }
}

public class ErrorResponse
{
    public string Message { get; set; }
    public int Error { get; set; }
}