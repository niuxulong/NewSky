namespace NewSky.Platform.Api.WebApi.Interfaces
{
	public interface IWebApiStartupController
	{
		void Start(string apiName);

		void Stop(string apiName);
	}
}
