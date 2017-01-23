using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using System.Web.Http;
using NewSky.Platform.Api.Interfaces;
using NewSky.Platform.Api.Models;
using NewSky.Platform.Service.Interfaces;

namespace NewSky.Platform.WebApi.Controllers
{
	public class UserController : AbstractApiController
	{
		[Import]
		private IUserHandler userHandler { get; set; }

		[AllowAnonymous]
		[Route("User/Register")]
		[AcceptVerbs("GET", "POST")]
		public async Task<IHttpActionResult> Register(User newUser)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var result = await this.userHandler.Create(newUser);

			return Ok();
		}

		[Route("User/Login")]
		[AcceptVerbs("GET", "POST")]
		public async Task<IHttpActionResult> Login(string uname, string pwd)
		{
			return Ok();
		}

		[Authorize]
		[Route("User/Get")]
		public async Task<IEnumerable<string>> GetUserInfo()
		{
			return new string[] { "128: Green Than", "223: Summer Whzd" };
		}
	}
}
