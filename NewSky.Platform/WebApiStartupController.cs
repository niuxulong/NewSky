using System;
using System.ComponentModel.Composition;
using System.Reflection;
using Microsoft.Owin.Hosting;
using NewSky.Platform.Interfaces;

namespace NewSky.Platform
{
	[Export(typeof(IWebApiStartupController))]
	public class WebApiStartupController : IWebApiStartupController
	{
		private IDisposable _apiServer = null;
		private readonly IProductControllerConfiguration productControllerConfiguration;

		[ImportingConstructor]
		public WebApiStartupController(IProductControllerConfiguration productControllerConfiguration)
		{
			this.productControllerConfiguration = productControllerConfiguration;
		}

		public void Start()
		{
			_apiServer = WebApp.Start<Startup>(url: productControllerConfiguration.BaseUri);
		}

		public void Stop()
		{
			if (_apiServer != null)
			{
				_apiServer.Dispose();
			}
		}
	}
}
