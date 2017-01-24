using System;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using NewSky.Platform.Api.WebApi.Providers;
using Owin;

namespace NewSky.Platform.Api.WebApi
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			ConfigureOAuth(app);

			HttpConfiguration config = new HttpConfiguration();

			config.MapHttpAttributeRoutes();
			config.Routes.MapHttpRoute(
					name: "DefaultApi",
					routeTemplate: "{controller}/{id}",
					defaults: new { id = RouteParameter.Optional }
				);

			app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
			app.UseWebApi(config);
		}

		public void ConfigureOAuth(IAppBuilder app)
		{
			OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
			{
				AllowInsecureHttp = true,
				TokenEndpointPath = new PathString("/token"),
				AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
				Provider = new SimpleAuthorizationServerProvider()
			};

			// Token Generation
			app.UseOAuthAuthorizationServer(OAuthServerOptions);
			app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

		}
	}
}
