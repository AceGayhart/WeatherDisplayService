using System.Text.Json.Serialization;

namespace WeatherDisplayService.Models.DataModels.OpenWeather;

/// <summary>
/// National weather alerts data from major national weather warning systems
/// </summary>
public class WeatherAlert
{
    /// <summary>
    /// Name of the alert source. Please read here the <see
    /// href="https://openweathermap.org/api/one-call-3#listsource">full list of alert sources</see>
    /// </summary>
    /// <remarks>
    /// National weather alerts are provided in English by default. Please note that some agencies
    /// provide the alert’s description only in a local language.
    /// </remarks>
    [JsonPropertyName("sender_name")]
    public string SenderName { get; set; } = string.Empty;

    /// <summary>
    /// Alert event name
    /// </summary>
    public string Event { get; set; } = string.Empty;

    /// <summary>
    /// Date and time of the start of the alert, Unix, UTC
    /// </summary>
    public long Start { get; set; }

    /// <summary>
    /// Date and time of the end of the alert, Unix, UTC
    /// </summary>
    public long End { get; set; }

    /// <summary>
    /// Description of the alert
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Type of severe weather
    /// </summary>
    /// <example>["Small", "Medium", "Large"]</example>
    public List<string> Tags { get; set; } = [];
}