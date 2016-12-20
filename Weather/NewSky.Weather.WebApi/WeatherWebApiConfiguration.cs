using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewSky.Platform.Interfaces;

namespace NewSky.Weather.WebApi
{
	[Export(typeof(IProductControllerConfiguration))]
	public class WeatherWebApiConfiguration : IProductControllerConfiguration
    {
		private readonly string baseUri;

		[ImportingConstructor]
		public WeatherWebApiConfiguration()
		{
			this.baseUri = "http://127.0.0.1:8901/api/Weather/";
		}

		public string BaseUri
		{
			get { return this.baseUri; }
		}
	}
}
