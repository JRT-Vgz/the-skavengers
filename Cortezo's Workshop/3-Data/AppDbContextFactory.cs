
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace _3___Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            optionsBuilder.UseSqlServer("Server=localhost; Database=CortezosWorkshop; Trusted_Connection=True; MultipleActiveResultSets=true; TrustServerCertificate=True;");


            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
