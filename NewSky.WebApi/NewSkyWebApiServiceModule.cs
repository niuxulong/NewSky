using System.ComponentModel.Composition;
using NewSky.Platform.Interfaces;

namespace NewSky.WebApi
{
	[Export(typeof(IServiceModule))]
	public class NewSkyWebApiServiceModule : IServiceModule
	{
		private readonly IWebApiStartupController webApiStartupController;

		[ImportingConstructor]
		public NewSkyWebApiServiceModule(IWebApiStartupController webApiStartupController)
		{
			this.webApiStartupController = webApiStartupController;
		}

		public void OnStart()
		{
			webApiStartupController.Start();
		}

		public void OnStop()
		{
			webApiStartupController.Stop();
		}
	}
}
