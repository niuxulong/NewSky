﻿using Owin;
using System.Reflection;
using System.Web.Http;

namespace ServiceShellHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
			
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );

            app.UseWebApi(config);
        }
    }
}
