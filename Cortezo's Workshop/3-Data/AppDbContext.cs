using _3___Data.Models;
using _3___Data.Models.ProductModels;
using Microsoft.EntityFrameworkCore;

namespace _3___Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<OreMapModel> OreMaps { get; set; }
        public DbSet<MaterialModel> Materials { get; set; }
        public DbSet<ShopStatsModel> ShopStats { get; set; }
        public DbSet<GenericProductModel> GenericProducts { get; set; }
        public DbSet<FullPlateModel> FullPlates { get; set; }
        public DbSet<ToolModel> Tools { get; set; }
        public DbSet<CommodityModel> Commodities { get; set; }
        public DbSet<IngotModel> Ingots { get; set; }
    }
}
