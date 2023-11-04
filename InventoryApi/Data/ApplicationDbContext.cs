using InventoryLogic.Models;
using InventoryLogic.Setting;
using Microsoft.EntityFrameworkCore;

namespace InventoryApi.Data
{
    public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}
		public DbSet<Brand> Brand { get; set; }
		public DbSet<Role> Role { get; set; }
		public DbSet<Users> Users { get; set; }
	}
}