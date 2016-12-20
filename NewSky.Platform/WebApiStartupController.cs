using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Reflection;
using Microsoft.Owin.Hosting;
using NewSky.Platform.Interfaces;

namespace NewSky.Platform
{
	[Export(typeof(IWebApiStartupController))]
	public class WebApiStartupController : IWebApiStartupController
	{
		private List<IDisposable> apiServers = new List<IDisposable>();

		[ImportMany]
		private IEnumerable<IProductControllerConfiguration> productControllerConfigurations;

		[ImportingConstructor]
		public WebApiStartupController()
		{
		}

		public void Start()
		{
			foreach (var config in productControllerConfigurations)
			{
				apiServers.Add(WebApp.Start<Startup>(url: config.BaseUri));
			}
		}

		public void Stop()
		{
			foreach (var apiServer in apiServers)
			{
				apiServer.Dispose();
			}
		}
	}
}
