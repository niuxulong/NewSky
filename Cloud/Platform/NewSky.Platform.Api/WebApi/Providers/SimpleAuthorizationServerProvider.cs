﻿using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using NewSky.Platform.Api.Entities;
using NewSky.Platform.Api.Utils;

namespace NewSky.Platform.Api.WebApi.Providers
{
	public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
	{
		public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
		{
			var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin");
			if (allowedOrigin == null)
			{
				allowedOrigin = "*";
			}

			context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

			using (var authRepository = new AuthRepository())
			{
				IdentityUser user = await authRepository.FindUser(context.UserName, context.Password).ConfigureAwait(false);
				if (user == null)
				{
					context.SetError("invalid_grand", "The user name or password is incorrect.");
					return;
				}
			}

			var identity = new ClaimsIdentity(context.Options.AuthenticationType);
			identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
			identity.AddClaim(new Claim("sub", context.UserName));
			identity.AddClaim(new Claim("role", "user"));

			var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    { "as:client_id", (context.ClientId == null) ? string.Empty : context.ClientId },
                    { "userName", context.UserName }
                });

			var ticket = new AuthenticationTicket(identity, props);
			context.Validated(ticket);
		}

		public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
		{
			string clientId = string.Empty;
			string clientSecret = string.Empty;
			Client client = null;

			if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
			{
				context.TryGetFormCredentials(out clientId, out clientSecret);
			}

			if (context.ClientId == null)
			{
				context.Validated();
				return Task.FromResult<object>(null);
			}

			using (var authRepository = new AuthRepository())
			{
				client = authRepository.FindClient(context.ClientId);
			}

			if (client == null)
			{
				context.SetError("invalid_clientId", string.Format("Client '{0}' is not registered in the system.", context.ClientId));
				return Task.FromResult<object>(null);
			}

			if (client.ApplicationType == Models.ApplicationTypes.NativeConfidential)
			{
				if (string.IsNullOrWhiteSpace(clientSecret))
				{
					context.SetError("invalid_clientId", "Client secret should be sent.");
					return Task.FromResult<object>(null);
				}
				else
				{
					if (client.Secret != Helper.GetHash(clientSecret))
					{
						context.SetError("invalid_clientId", "Client secret is invalid.");
						return Task.FromResult<object>(null);
					}
				}
			}

			if (client.Active == 0)
			{
				context.SetError("invalid_clientId", "Client is inactive.");
				return Task.FromResult<object>(null);
			}

			context.OwinContext.Set<string>("as:clientAllowedOrigin", client.AllowedOrigin);
			context.OwinContext.Set<string>("as:clientRefreshTokenLifeTime", client.RefreshTokenLifeTime.ToString());

			context.Validated();
			return Task.FromResult<object>(null);
		}

		public override Task TokenEndpoint(OAuthTokenEndpointContext context)
		{
			foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
			{
				context.AdditionalResponseParameters.Add(property.Key, property.Value);
			}

			return Task.FromResult<object>(null);
		}

		public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
		{
			var originalClient = context.Ticket.Properties.Dictionary["as:client_id"];
			var currentClient = context.ClientId;

			if (originalClient != currentClient)
			{
				context.SetError("invalid_clientId", "Refresh token is issued to a different clientId.");
				return Task.FromResult<object>(null);
			}

			var newIdentity = new ClaimsIdentity(context.Ticket.Identity);
			newIdentity.AddClaim(new Claim("newClaim", "newValue"));

			var newTickit = new AuthenticationTicket(newIdentity, context.Ticket.Properties);
			context.Validated(newTickit);

			return Task.FromResult<object>(null);
		}
	}
}
