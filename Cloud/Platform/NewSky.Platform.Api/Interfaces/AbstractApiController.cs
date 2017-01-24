using System.Web.Http;

namespace NewSky.Platform.Api.Interfaces
{
	public class AbstractApiController : ApiController
	{
		public AbstractApiController()
		{
			IoC.ComposeParts(this);
		}
	}
}
