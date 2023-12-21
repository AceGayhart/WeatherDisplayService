namespace WeatherDisplayService.Models.DataModels.OpenWeather;

public class DailyTemperature
{
    /// <summary>
    /// Morning temperature.
    /// </summary>
    public double Morn { get; set; }

    /// <summary>
    /// Day temperature.
    /// </summary>
    public double Day { get; set; }

    /// <summary>
    /// Evening temperature.
    /// </summary>
    public double Eve { get; set; }

    /// <summary>
    /// Night temperature.
    /// </summary>

    public double Night { get; set; }

    /// <summary>
    /// Min daily temperature.
    /// </summary>

    public double Min { get; set; }
    /// <summary>
    /// Max daily temperature.
    /// </summary>

    public double Max { get; set; }
}
