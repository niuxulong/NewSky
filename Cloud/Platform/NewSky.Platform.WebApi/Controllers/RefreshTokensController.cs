using System.ComponentModel.Composition;
using System.Threading.Tasks;
using System.Web.Http;
using NewSky.Platform.Api.Interfaces;

namespace NewSky.Platform.WebApi.Controllers
{
	public class RefreshTokensController : AbstractApiController
	{
		[Import]
		private IAuthRepository authRepository { get; set; }

		[Authorize]
		public IHttpActionResult Get()
		{
			return Ok(authRepository.GetAllRefreshTokens());
		}

		[AllowAnonymous]
		public async Task<IHttpActionResult> Delete(string tokenId)
		{
			var result = await authRepository.RemoveRefreshToken(tokenId).ConfigureAwait(false);
			if (result)
			{
				return Ok();
			}

			return BadRequest("Token Id does not exist");
		}
	}
}
