using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using NewSky.Platform.Api.Models;
using NewSky.Platform.Service.Interfaces;

namespace NewSky.Platform.Service.Handlers
{
	[Export(typeof(IUserHandler)), PartCreationPolicy(CreationPolicy.Shared)]
	public class UserHandler : IUserHandler
	{
		private List<User> users = new List<User>();

		[ImportingConstructor]
		public UserHandler()
		{
		}

		public async Task<bool> Create(User newUser)
		{
			users.Add(newUser);
			return true;
		}
	}
}
