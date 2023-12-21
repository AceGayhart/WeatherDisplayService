# WeatherDisplayService

This is the backend service for my [Weather Display](https://github.com/AceGayhart/weather-display)
project. I needed a quick and dirty service just so I could publish the front end without exposing
API keys. Of course, since the intent is to just have this deployed locally, this meager project is
likely overkill.


## TODO / Ideas:

- Create new View Models
- Swagger should show request examples
- View Models should have example values for Swagger
- Create separate endpoints:
	- Authentication: 
		- Allow for JWT authentication (primarily for front-end)
		- Allow for Username/Password authentication (or JWT credential creation) for configuration changes.
	- Weather:
		- Current Conditions
		- Daily Forecast
		- Hourly Forecast
		- Preciptation Forecast
- The response from the back-end service should change to pre-calculate some information. For example it would be helpful if hourly data included events happening during that hour. It may be helpful to have different endpoints for the various types of data.

## Resources / Links

- <https://swagger.io/docs/specification/about/>
- <https://github.com/domaindrivendev/Swashbuckle.AspNetCore>
