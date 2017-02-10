﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using NewSky.Platform.Api.Entities;

namespace NewSky.Platform.Api
{
	public class AuthContext : IdentityDbContext<IdentityUser>
	{
		public AuthContext()
			: base(@"server=.\sql12;database=NewSky;uid=sa;password=ezetc")
		{
		}

		public DbSet<Client> Clients { get; set; }

		public DbSet<RefreshToken> RefreshTokens { get; set; }
	}
}