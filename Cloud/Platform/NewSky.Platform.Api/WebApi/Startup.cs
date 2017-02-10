using System;
using System.Data.Entity;
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
				// The path for generatiog tokens will be as "http://localhost:port/token".
				TokenEndpointPath = new PathString("/token"),
				// Specify the expiry for token.
				AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
				// Specify how to validate the credentials for users asking for tokens.
				Provider = new SimpleAuthorizationServerProvider(),
				RefreshTokenProvider = new SimpleRefreshTokenProvider()
			};

			// Token Generation
			app.UseOAuthAuthorizationServer(OAuthServerOptions);
			app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
		}
	}
}
