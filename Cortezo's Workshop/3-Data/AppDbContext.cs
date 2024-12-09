using _3___Data.Models;
using Microsoft.EntityFrameworkCore;

namespace _3___Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<OreMapModel> OreMaps { get; set; }
        public DbSet<MaterialModel> Materials { get; set; }
        public DbSet<ShopStatsModel> ShopStats { get; set; }
        public DbSet<ProductModel> Products { get; set; }
    }
}
