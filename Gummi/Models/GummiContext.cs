using System;
using Microsoft.EntityFrameworkCore;

namespace Gummi.Models
{
	public class GummiDbContext : DbContext
	{
		public GummiDbContext()
		{
		}

		public virtual DbSet<Product> Products { get; set; }

		public virtual DbSet<Review> Reviews { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseMySql(@"Server=localhost;Port=8889;database=Gummi;uid=root;pwd=root;");
		}

		public GummiDbContext(DbContextOptions<GummiDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}
	}
}
