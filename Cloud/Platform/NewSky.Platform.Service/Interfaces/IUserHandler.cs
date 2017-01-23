using System.Threading.Tasks;
using NewSky.Platform.Api.Models;

namespace NewSky.Platform.Service.Interfaces
{
	public interface IUserHandler
	{
		Task<bool> Create(User newUser);
	}
}
