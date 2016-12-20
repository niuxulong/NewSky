using System.ComponentModel.Composition;
using NewSky.Platform.Interfaces;

namespace NewSky.User.WebApi
{
	[InheritedExport(typeof(IProductControllerConfiguration))]
	public class UserWebApiConfiguration : IProductControllerConfiguration
	{
		private readonly string baseUri;

		[ImportingConstructor]
		public UserWebApiConfiguration()
		{
			this.baseUri = "http://127.0.0.1:8901/api/User/";
		}

		public string BaseUri
		{
			get { return this.baseUri; }
		}
	}
}
