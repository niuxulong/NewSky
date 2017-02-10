using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using NewSky.Platform.Api.Interfaces;
using NewSky.Platform.Api.Models;
using NewSky.Platform.Service.Interfaces;

namespace NewSky.Platform.WebApi.Controllers
{
	public class UserController : AbstractApiController
	{
		[Import]
		private IUserHandler userHandler { get; set; }

		[Import]
		private IAuthRepository authRepository { get; set; }

		[AllowAnonymous]
		[Route("User/Register")]
		[AcceptVerbs("GET", "POST")]
		public async Task<IHttpActionResult> Register(User newUser)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			IdentityResult result = await authRepository.RegisterUser(newUser).ConfigureAwait(false);

			IHttpActionResult errorResult = GetErrorResult(result);

			if (errorResult != null)
			{
				return errorResult;
			}

			return Ok();
		}

		[Authorize]
		[Route("User/Get")]
		public async Task<IEnumerable<string>> GetUserInfo()
		{
			return new string[] { "128: Green Than", "223: Summer Whzd" };
		}

		private IHttpActionResult GetErrorResult(IdentityResult result)
		{
			if (result == null)
			{
				return InternalServerError();
			}

			if (!result.Succeeded)
			{
				if (result.Errors != null)
				{
					foreach (var error in result.Errors)
					{
						ModelState.AddModelError("", error);
					}
				}

				if (ModelState.IsValid)
				{
					return BadRequest();
				}
			}

			return null;
		}

	}
}
