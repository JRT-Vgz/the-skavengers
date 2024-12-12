using _3___Data.Models;
using Microsoft.EntityFrameworkCore;

namespace _3___Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<MaterialModel> Materials { get; set; }
        public DbSet<ShopStatsModel> ShopStats { get; set; }
        public DbSet<GenericProductModel> GenericProducts { get; set; }
        public DbSet<IngotResourceModel> IngotResources { get; set; }
    }
}
