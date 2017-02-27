using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using NewSky.Platform.Api.Models;

namespace NewSky.Platform.Service.Interfaces
{
	public interface IUserManager
	{
		Task<IdentityResult> CreateUser(User user);
	}
}
