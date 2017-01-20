using System.ComponentModel.Composition;
using NewSky.Platform.Api.WebApi.Interfaces;

namespace NewSky.Platform.WebApi
{
	public class WebApiConfiguration : IProductControllerConfiguration
    {
		private readonly string baseUri;

		[ImportingConstructor]
		public WebApiConfiguration()
		{
			this.baseUri = "http://127.0.0.1:8901/api/User/";
		}

		public string BaseUri
		{
			get { return this.baseUri; }
		}
    }
}
