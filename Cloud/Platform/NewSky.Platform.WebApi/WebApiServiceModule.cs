using System.ComponentModel.Composition;
using NewSky.Platform.Api.WebApi.Interfaces;

namespace NewSky.Platform.WebApi
{
	[Export(typeof(IServiceModule)), PartCreationPolicy(CreationPolicy.Shared)]
	public class WebApiServiceModule : IServiceModule
	{
		private readonly IWebApiStartupController webApiStartupController;
		
		[ImportingConstructor]
		public WebApiServiceModule(IWebApiStartupController webApiStartupController)
		{
			this.webApiStartupController = webApiStartupController;
		}

		public void OnStart()
		{
			webApiStartupController.Start(Constants.PLATFORM_WEBAPI);
		}

		public void OnStop()
		{
			webApiStartupController.Stop(Constants.PLATFORM_WEBAPI);
		}
	}
}
