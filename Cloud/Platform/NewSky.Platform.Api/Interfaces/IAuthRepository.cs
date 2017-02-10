using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NewSky.Platform.Api.Entities;
using NewSky.Platform.Api.Models;

namespace NewSky.Platform.Api.Interfaces
{
	public interface IAuthRepository : IDisposable
	{
		Task<IdentityResult> RegisterUser(User userModel);

		Task<IdentityUser> FindUser(string userName, string password);

		List<RefreshToken> GetAllRefreshTokens();

		Task<bool> RemoveRefreshToken(string refreshTokenId);
	}
}
