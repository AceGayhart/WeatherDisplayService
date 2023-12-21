using System.Text.Json.Serialization;

namespace WeatherDisplayService.Models.DataModels.OpenWeather;

public class HourlyForecast
{
    /// <summary>
    /// Time of the forecasted data, Unix, UTC
    /// </summary>
    public long Dt { get; set; }

    /// <summary>
    /// Temperature. Units - default: kelvin, metric: Celsius, imperial: Fahrenheit. <see
    /// href="https://openweathermap.org/api/one-call-3#data">How to change units used</see>
    /// </summary>
    public double Temp { get; set; }

    /// <summary>
    /// Temperature. This temperature parameter accounts for the human perception of weather. Units
    /// – default: kelvin, metric: Celsius, imperial: Fahrenheit.
    /// </summary>
    [JsonPropertyName("feels_like")]
    public double FeelsLike { get; set; }

    /// <summary>
    /// Atmospheric pressure on the sea level, hPa
    /// </summary>
    public int Pressure { get; set; }

    /// <summary>
    /// Humidity, %
    /// </summary>
    public int Humidity { get; set; }

    /// <summary>
    /// Atmospheric temperature (varying according to pressure and humidity) below which water
    /// droplets begin to condense and dew can form. Units – default: kelvin, metric: Celsius,
    /// imperial: Fahrenheit
    /// </summary>
    [JsonPropertyName("dew_point")]
    public double DewPoint { get; set; }

    /// <summary>
    /// Current UV index.
    /// </summary>
    public double Uvi { get; set; }

    /// <summary>
    /// Cloudiness, %
    /// </summary>
    public int Clouds { get; set; }

    /// <summary>
    /// Average visibility, metres. The maximum value of the visibility is 10 km
    /// </summary>
    public int Visibility { get; set; }

    /// <summary>
    /// Wind speed. Units – default: metre/sec, metric: metre/sec, imperial: miles/hour. <see
    /// href="https://openweathermap.org/api/one-call-3#data">How to change units used</see>
    /// </summary>
    [JsonPropertyName("wind_speed")] 
    public double WindSpeed { get; set; }

    /// <summary>
    /// (where available) Wind gust. Units – default: metre/sec, metric: metre/sec, imperial:
    /// miles/hour. <see href="https://openweathermap.org/api/one-call-3#data">How to change units used</see>
    /// </summary>
    [JsonPropertyName("wind_gust")] 
    public double? WindGust { get; set; }

    /// <summary>
    /// Wind direction, degrees (meteorological)
    /// </summary>
    [JsonPropertyName("wind_deg")]
    public int WindDeg { get; set; }

    /// <summary>
    /// Probability of precipitation. The values of the parameter vary between 0 and 1, where 0 is
    /// equal to 0%, 1 is equal to 100%
    /// </summary>
    public double Pop { get; set; }

    /// <summary>
    /// Precipitation, mm/h. Please note that only mm/h as units of measurement are available for
    /// this parameter
    /// </summary>
    [JsonPropertyName("rain.1h")]
    public double? Rain { get; set; }

    /// <summary>
    /// Precipitation, mm/h. Please note that only mm/h as units of measurement are available for
    /// this parameter
    /// </summary>
    [JsonPropertyName("snow.1h")]
    public double? Snow { get; set; }

    public List<WeatherCondition> Weather { get; set; } = [];
}