using System.Data.Entity.Migrations;
using NewSky.Platform.Api.DbContexts;

namespace NewSky.Platform.Api.Migrations
{
	internal sealed class Configuration : DbMigrationsConfiguration<AuthContext>
	{
		//public Configuration()
		//{
		//	AutomaticMigrationsEnabled = false;
		//}

		//protected override void Seed(AuthContext context)
		//{
			//if (context.Clients.Count() > 0)
			//{
			//	return;
			//}

			//context.Clients.AddRange(BuildClientsList());
			//context.SaveChanges();
		//}

		//private static List<Client> BuildClientsList()
		//{

		//	List<Client> ClientsList = new List<Client> 
		//	{
		//		new Client
		//		{ 
		//			Id = "ngAuthApp", 
		//			Secret= Helper.GetHash("abc@123"), 
		//			Name="AngularJS front-end Application", 
		//			ApplicationType =  Models.ApplicationTypes.JavaScript, 
		//			Active = 1, 
		//			RefreshTokenLifeTime = 7200, 
		//			AllowedOrigin = "http://lawrenceniu:3457"
		//		},
		//		new Client
		//		{ 
		//			Id = "consoleApp", 
		//			Secret=Helper.GetHash("123@abc"), 
		//			Name="Console Application", 
		//			ApplicationType =Models.ApplicationTypes.NativeConfidential, 
		//			Active = 1, 
		//			RefreshTokenLifeTime = 14400, 
		//			AllowedOrigin = "*"
		//		}
		//	};

		//	return ClientsList;
		//}
	}
}
