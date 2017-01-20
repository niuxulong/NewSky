using System.ComponentModel.Composition;
using NewSky.Platform.Api.WebApi.Interfaces;

namespace NewSky.Platform.WebApi
{
	[Export(typeof(IServiceModule)), PartCreationPolicy(CreationPolicy.Shared)]
	public class WebApiServiceModule : IServiceModule
	{
		private readonly IWebApiStartupController webApiServiceModule;
		
		[ImportingConstructor]
		public WebApiServiceModule(IWebApiStartupController webApiStartupController)
		{
			this.webApiServiceModule = webApiStartupController;
		}

		public void OnStart()
		{
			webApiServiceModule.Start();
		}

		public void OnStop()
		{
			webApiServiceModule.Stop();
		}
	}
}
