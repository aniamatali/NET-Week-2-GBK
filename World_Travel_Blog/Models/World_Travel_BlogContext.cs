using System;
using Microsoft.EntityFrameworkCore;

namespace World_Travel_Blog.Models
{
	public class WorldTravelDbContext : DbContext
	{
		public WorldTravelDbContext()
		{
		}

		public DbSet<Location> Locations { get; set; }

		public DbSet<Experience> Experiences { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseMySql(@"Server=localhost;Port=8889;database=World_Travel_Blog;uid=root;pwd=root;");
		}

		public WorldTravelDbContext(DbContextOptions<WorldTravelDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}
	}
}