using Swashbuckle.AspNetCore.Filters;

namespace WeatherDisplayService.Controllers;

public class WeatherRequestExample : IExamplesProvider<WeatherRequest>
{
    public WeatherRequest GetExamples()
    {
        return 
             new WeatherRequest()
             {
                 Latitude = 41.472574,
                 Longitude = -82.140319
             };
    }

    //IEnumerable<SwaggerExample<WeatherRequest>> IMultipleExamplesProvider<WeatherRequest>.GetExamples()
    //{
    //    yield return SwaggerExample.Create(
    //        "Default",
    //        new WeatherRequest()
    //        {
    //            Latitude = 41.472574,
    //            Longitude = -82.140319
    //        });
    //}
    
}
