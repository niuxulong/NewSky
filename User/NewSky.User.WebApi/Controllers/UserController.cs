using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace NewSky.User.WebApi.Controllers
{
	public class UserController : ApiController
	{
		[HttpGet]
		public IEnumerable<string> GetUserInfo()
		{
			return new string[] { "18: Green Than", "22: Summer Whz" };
		}
	}
}
