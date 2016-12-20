using System.ComponentModel.Composition;
using NewSky.Platform.Interfaces;

namespace NewSky.Weather.WebApi
{
	[Export(typeof(IServiceModule)), PartCreationPolicy(CreationPolicy.Shared)]
	public class WeatherWebApiServiceModule : IServiceModule
	{
		private readonly IWebApiStartupController webApiStartupController;

		[ImportingConstructor]
		public WeatherWebApiServiceModule(IWebApiStartupController webApiStartupController)
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
