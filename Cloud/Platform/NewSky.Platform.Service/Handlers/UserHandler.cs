using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using NewSky.Platform.Api.Interfaces;
using NewSky.Platform.Api.Models;
using NewSky.Platform.Service.Interfaces;

namespace NewSky.Platform.Service.Handlers
{
	[Export(typeof(UserHandler)), PartCreationPolicy(CreationPolicy.Shared)]
	public class UserHandler
	{
		private List<User> users = new List<User>();
		private readonly IUserManager userManager;

		[ImportingConstructor]
		public UserHandler(IUserManager userManager)
		{
			this.userManager = userManager;
		}

		public async Task<IdentityResult> Create(User newUser)
		{
			return await userManager.CreateUser(newUser).ConfigureAwait(false);
		}
	}
}
