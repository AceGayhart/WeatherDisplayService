namespace WeatherDisplayService.Models.DataModels.OpenWeather;

public class WeatherCondition
{
    /// <summary>
    /// <see href="https://openweathermap.org/weather-conditions#Weather-Condition-Codes-2">Weather
    /// condition id</see>
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Group of weather parameters (Rain, Snow etc.)
    /// </summary>
    public string Main { get; set; } = string.Empty;

    /// <summary>
    /// Weather condition within the group ( <see
    /// href="https://openweathermap.org/weather-conditions#Weather-Condition-Codes-2">full list of
    /// weather conditions</see>). Get the output in <see
    /// href="https://openweathermap.org/api/one-call-3#multi">your language</see>
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Weather icon id. <see
    /// href="https://openweathermap.org/weather-conditions#How-to-get-icon-URL">How to get icons</see>
    /// </summary>
    public string Icon { get; set; } = string.Empty;
}