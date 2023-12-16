using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Swashbuckle.AspNetCore.Filters;
using System.Net;

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

    public WeatherController(IMemoryCache cache, IConfiguration configuration, HttpClient httpClient)
    {
        _cache = cache;
        _configuration = configuration;
        _httpClient = httpClient;
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
    public async Task<IActionResult> GetWeather([FromQuery] WeatherRequest request)
    {
        string units = "standard";
        // TODO: Store & return as JSON object.
        var cacheKey = $"Weather_{request.Latitude}_{request.Longitude}_{units}";
        if (_cache.TryGetValue(cacheKey, out string cachedResponse))
        {
            
            return new ContentResult
            {
                Content = cachedResponse,
                ContentType = "application/json",
                StatusCode = 200
            };
        }

        string apiKey = _configuration["OpenWeatherMapApiKey"];
        string url = $"{BaseUrl}?lat={request.Latitude}&lon={request.Longitude}&units={units}&appid={apiKey}";

        HttpResponseMessage response = await _httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            
            var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(10));
            _cache.Set(cacheKey, content, cacheEntryOptions);

            return new ContentResult
            {
                Content = content,
                ContentType = "application/json",
                StatusCode = 200
            };
        }

        return BadRequest("Error fetching weather data");
    }
}