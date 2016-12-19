using System.Collections.Generic;
using System.Web.Http;

namespace NewSky.WebApi.Controllers
{
    public class NewSkyController : ApiController
    {
        [HttpGet]
        public IEnumerable<string> GetInfo()
        {
            return new string[] { "lanNew11", "CheryNew" };
        }
    }
}
