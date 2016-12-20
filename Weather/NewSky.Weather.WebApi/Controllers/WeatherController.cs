using System.Collections.Generic;
using System.Web.Http;

namespace NewSky.Weather.WebApi.Controllers
{
	public class WeatherController : ApiController
	{
		[HttpGet]
		public IEnumerable<string> GetWeatherInfo()
		{
			return new string[] { "Monday: Sunny", "Tuesday: Rainning" };
		}
	}
}
