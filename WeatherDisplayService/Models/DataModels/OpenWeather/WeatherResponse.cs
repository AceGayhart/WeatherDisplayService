// Reference: https://openweathermap.org/api/one-call-3

using System.Text.Json.Serialization;

namespace WeatherDisplayService.Models.DataModels.OpenWeather;

public class WeatherResponse
{
    /// <summary>
    /// Latitude of the location, decimal (−90; 90)
    /// </summary>
    /// <example>41.4726</example>
    public double Lat { get; set; }

    /// <summary>
    /// Longitude of the location, decimal (-180; 180)
    /// </summary>
    /// <example>-82.1403</example>
    public double Lon { get; set; }

    /// <summary>
    /// Timezone name for the requested location
    /// </summary>
    /// <example>America/New_York</example>
    public string Timezone { get; set; } = string.Empty;

    /// <summary>
    /// Shift in seconds from UTC
    /// </summary>
    [JsonPropertyName("timezone_offset")]
    public int TimezoneOffset { get; set; }

    /// <summary>
    /// Current weather data API response
    /// </summary>
    public CurrentWeather Current { get; set; } = new CurrentWeather();

    /// <summary>
    /// Minute forecast weather data API response
    /// </summary>
    public List<MinutelyForecast> Minutely { get; set; } = [];

    /// <summary>
    /// Hourly forecast weather data API response
    /// </summary>
    public List<HourlyForecast> Hourly { get; set; } = [];

    /// <summary>
    /// Daily forecast weather data API response
    /// </summary>
    public List<DailyForecast> Daily { get; set; } = [];

    /// <summary>
    /// National weather alerts data from major national weather warning systems
    /// </summary>
    public List<WeatherAlert>? Alerts { get; set; }
}