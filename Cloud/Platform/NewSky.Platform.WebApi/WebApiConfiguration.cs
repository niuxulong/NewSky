using System.ComponentModel.Composition;
using NewSky.Platform.Api.WebApi.Interfaces;

namespace NewSky.Platform.WebApi
{
	[Export(typeof(IProductControllerConfiguration))]
	public class WebApiConfiguration : IProductControllerConfiguration
    {
		private readonly string baseUri;
		private readonly string apiName;

		[ImportingConstructor]
		public WebApiConfiguration()
		{
			this.baseUri = Constants.PLATFORM_WEBAPI_BASEURI;
			this.apiName = Constants.PLATFORM_WEBAPI;
		}

		public string BaseUri
		{
			get { return this.baseUri; }
		}

		public string ApiName
		{
			get { return this.apiName; }
		}
    }
}
