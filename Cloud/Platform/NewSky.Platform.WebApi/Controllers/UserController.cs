using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using NewSky.Platform.Api.Interfaces;
using NewSky.Platform.Api.Models;
using NewSky.Platform.Service.Handlers;

namespace NewSky.Platform.WebApi.Controllers
{
	public class UserController : AbstractApiController
	{
		[Import]
		private UserHandler userHandler { get; set; }

		[AllowAnonymous]
		[Route("User/Register")]
		[AcceptVerbs("GET", "POST")]
		public async Task<IHttpActionResult> Register(User newUser)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState.Values.FirstOrDefault().Errors.FirstOrDefault().ErrorMessage);
				}

				var result = await userHandler.Create(newUser).ConfigureAwait(false);

				IHttpActionResult errorResult = GetErrorResult(result);

				if (errorResult != null)
				{
					return errorResult;
				}

				return Ok();
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
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
