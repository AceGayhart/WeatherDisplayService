namespace WeatherDisplayService.Models.DataModels.OpenWeather;

public class MinutelyForecast
{
    /// <summary>
    /// Time of the forecasted data, unix, UTC
    /// </summary>
    public long Dt { get; set; }

    /// <summary>
    /// Precipitation, mm/h. Please note that only mm/h as units of measurement are available for this parameter
    /// </summary>
    public double Precipitation { get; set; }
}
