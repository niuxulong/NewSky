using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NewSky.Platform.Api.DbContexts;
using NewSky.Platform.Api.Entities;
using NewSky.Platform.Api.Interfaces;
using NewSky.Platform.Api.Models;

namespace NewSky.Platform.Api
{
	[Export(typeof(IAuthRepository)), PartCreationPolicy(CreationPolicy.Shared)]
	public class AuthRepository : IAuthRepository
	{
		private AuthContext ctx;
		private UserManager<IdentityUser> userManager;

		[ImportingConstructor]
		public AuthRepository()
		{
			ctx = new AuthContext();
			userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(ctx));
		}

		public async Task<IdentityResult> RegisterUser(User userModel)
		{ 
			IdentityUser user = new IdentityUser
			{
				UserName = userModel.UserName
			};

			var result = await userManager.CreateAsync(user, userModel.Password);
			return result;
		}

		public async Task<IdentityUser> FindUser(string userName, string password)
		{
			return await userManager.FindAsync(userName, password);
		}

		public Client FindClient(string clientId)
		{
			return ctx.Clients.Find(clientId);
		}

		public async Task<bool> AddRefreshToken(RefreshToken token)
		{
			try
			{
				var existingToken = ctx.RefreshTokens.Where(r => r.Subject == token.Subject && r.ClientId == token.ClientId).SingleOrDefault();
				if (existingToken != null)
				{
					var result = await RemoveRefreshToken(existingToken).ConfigureAwait(false);
				}

				ctx.RefreshTokens.Add(token);
				var eResult = await ctx.SaveChangesAsync().ConfigureAwait(false);
				return eResult > 0;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<bool> RemoveRefreshToken(string refreshTokenId)
		{
			var refreshToken = await ctx.RefreshTokens.FindAsync(refreshTokenId);

			if (refreshToken != null)
			{
				ctx.RefreshTokens.Remove(refreshToken);
				return await ctx.SaveChangesAsync() > 0;
			}

			return false;
		}

		public async Task<bool> RemoveRefreshToken(RefreshToken refreshToken)
		{
			ctx.RefreshTokens.Remove(refreshToken);
			return await ctx.SaveChangesAsync() > 0;
		}

		public async Task<RefreshToken> FindRefreshToken(string refreshTokenId)
		{
			var refreshToken = await ctx.RefreshTokens.FindAsync(refreshTokenId);

			return refreshToken;
		}

		public List<RefreshToken> GetAllRefreshTokens()
		{
			return ctx.RefreshTokens.ToList();
		}

		public void Dispose()
		{
			ctx.Dispose();
			userManager.Dispose();
		}
	}
}
