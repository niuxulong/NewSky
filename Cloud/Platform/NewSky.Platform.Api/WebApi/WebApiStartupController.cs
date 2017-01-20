using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Microsoft.Owin.Hosting;
using NewSky.Platform.Api.WebApi.Interfaces;

namespace NewSky.Platform.Api.WebApi
{
	[Export(typeof(IWebApiStartupController))]
	public class WebApiStartupController : IWebApiStartupController
	{
		private IDictionary<string, IDisposable> apiServers = new Dictionary<string, IDisposable>();

		private IDictionary<string, IProductControllerConfiguration> productControllerConfigurationsDic;

		[ImportingConstructor]
		public WebApiStartupController([ImportMany] IEnumerable<IProductControllerConfiguration> productControllerConfigurations)
		{
			this.productControllerConfigurationsDic = productControllerConfigurations.ToDictionary(x => x.ApiName, x => x);
		}

		public void Start(string apiName)
		{
			var config = productControllerConfigurationsDic[apiName];
			apiServers.Add(config.ApiName, WebApp.Start<Startup>(url: config.BaseUri));
		}

		public void Stop(string apiName)
		{
			apiServers[apiName].Dispose();
		}
	}
}
