
using _3_Data.Armory.Models;
using Microsoft.EntityFrameworkCore;

namespace _3_Data.Armory
{
    public class ArmoryDbContext : DbContext
    {
        public ArmoryDbContext(DbContextOptions<ArmoryDbContext> options) : base(options) { }

        public DbSet<ScriptModel> Scripts { get; set; }
    }
}
