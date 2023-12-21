using System.Text.Json.Serialization;

namespace WeatherDisplayService.Models.DataModels.OpenWeather;

public class DailyForecast
{
    /// <summary>
    /// Time of the forecasted data, Unix, UTC
    /// </summary>
    public long Dt { get; set; }

    /// <summary>
    /// Sunrise time, Unix, UTC. For polar areas in midnight sun and polar night periods this
    /// parameter is not returned in the response
    /// </summary>
    public long? Sunrise { get; set; }

    /// <summary>
    /// Sunset time, Unix, UTC. For polar areas in midnight sun and polar night periods this
    /// parameter is not returned in the response
    /// </summary>
    public long? Sunset { get; set; }

    /// <summary>
    /// The time of when the moon rises for this day, Unix, UTC
    /// </summary>
    public long Moonrise { get; set; }

    /// <summary>
    /// The time of when the moon sets for this day, Unix, UTC
    /// </summary>
    public long Moonset { get; set; }

    /// <summary>
    /// Moon phase. 0 and 1 are 'new moon', 0.25 is 'first quarter moon', 0.5 is 'full moon' and
    /// 0.75 is 'last quarter moon'. The periods in between are called 'waxing crescent', 'waxing
    /// gibbous', 'waning gibbous', and 'waning crescent', respectively. Moon phase calculation
    /// algorithm: if the moon phase values between the start of the day and the end of the day have
    /// a round value (0, 0.25, 0.5, 0.75, 1.0), then this round value is taken, otherwise the
    /// average of moon phases for the start of the day and the end of the day is taken
    /// </summary>
    [JsonPropertyName("moon_phase")]
    public double MoonPhase { get; set; }

    /// <summary>
    /// Human-readable description of the weather conditions for the day
    /// </summary>
    public string Summary { get; set; } = string.Empty;

    /// <summary>
    /// Temperature. Units - default: kelvin, metric: Celsius, imperial: Fahrenheit. <see
    /// href="https://openweathermap.org/api/one-call-3#data">How to change units used</see>
    /// </summary>
    public DailyTemperature Temp { get; set; } = new DailyTemperature();

    /// <summary>
    /// Temperature. This accounts for the human perception of weather. Units – default: kelvin,
    /// metric: Celsius, imperial: Fahrenheit.
    /// </summary>
    [JsonPropertyName("feels_like")]
    public DailyFeelsLike FeelsLike { get; set; } = new DailyFeelsLike();

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
    /// Cloudiness, %
    /// </summary>
    public int Clouds { get; set; }

    /// <summary>
    /// Current UV index.
    /// </summary>
    public double Uvi { get; set; }

    /// <summary>
    /// Probability of precipitation. The values of the parameter vary between 0 and 1, where 0 is
    /// equal to 0%, 1 is equal to 100%
    /// </summary>
    public double Pop { get; set; }

    /// <summary>
    /// Precipitation, mm/h. Please note that only mm/h as units of measurement are available for
    /// this parameter
    /// </summary>
    public double? Rain { get; set; }

    /// <summary>
    /// Precipitation, mm/h. Please note that only mm/h as units of measurement are available for
    /// this parameter
    /// </summary>
    public double? Snow { get; set; }

    public List<WeatherCondition> Weather { get; set; } = [];
}