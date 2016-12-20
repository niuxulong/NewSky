using System.ComponentModel.Composition;
using NewSky.Platform.Interfaces;

namespace NewSky.User.WebApi
{
	[Export(typeof(IServiceModule)), PartCreationPolicy(CreationPolicy.Shared)]
	public class UserWebApiServiceModule : IServiceModule
    {
		private readonly IWebApiStartupController webApiStartupController;
		
		[ImportingConstructor]
		public UserWebApiServiceModule(IWebApiStartupController webApiStartupController)
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
