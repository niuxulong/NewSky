using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using NewSky.Platform.Api.Interfaces;
using NewSky.Platform.Api.Models;
using NewSky.Platform.Service.Interfaces;

namespace NewSky.Platform.Service.Services
{
	[Export(typeof(IUserManager)), PartCreationPolicy(CreationPolicy.Shared)]
	public class UserManager : IUserManager
	{
		private readonly IAuthRepository authRepository;

		[ImportingConstructor]
		public UserManager(IAuthRepository authRepository)
		{
			this.authRepository = authRepository;
		}

		public async Task<IdentityResult> CreateUser(User user)
		{
			return await authRepository.RegisterUser(user).ConfigureAwait(false);
		}
	}
}
