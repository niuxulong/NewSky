using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using NewSky.Platform.Api.Entities;

namespace NewSky.Platform.Api.DbContexts
{
	public class AuthContext : IdentityDbContext<IdentityUser>
	{
		public AuthContext()
			: base("NewSkyDatabase")
		{
			Database.SetInitializer<AuthContext>(new CreateDatabaseIfNotExists<AuthContext>());
		}

		public DbSet<Client> Clients { get; set; }

		public DbSet<RefreshToken> RefreshTokens { get; set; }
	}
}
