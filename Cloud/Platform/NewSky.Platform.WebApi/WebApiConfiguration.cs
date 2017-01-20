using System.ComponentModel.Composition;
using NewSky.Platform.Api.WebApi.Interfaces;

namespace NewSky.Platform.WebApi
{
	[Export(typeof(IProductControllerConfiguration))]
	public class WebApiConfiguration : IProductControllerConfiguration
    {
		private readonly string baseUri;

		[ImportingConstructor]
		public WebApiConfiguration()
		{
			this.baseUri = "http://127.0.0.1:8901/api/platform/";
		}

		public string BaseUri
		{
			get { return this.baseUri; }
		}
    }
}
