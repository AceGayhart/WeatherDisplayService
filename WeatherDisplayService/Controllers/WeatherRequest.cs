using System.ComponentModel.DataAnnotations;

namespace WeatherDisplayService.Controllers;


public class WeatherRequest
{

    /// <summary>
    /// The latitude coordinate.
    /// </summary>
    [Required]
    public double Latitude { get; set; }

    /// <summary>
    /// The longitude coordinate.
    /// </summary>
    [Required]    
    public double Longitude { get; set; }

    
}