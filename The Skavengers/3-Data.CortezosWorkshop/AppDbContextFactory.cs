
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using _3_Encrypters.TheSkavengers;

namespace _3_Data.CortezosWorkshop
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var connectionString = "Connection string";
            //var connectionString = "Encripted string";

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(DBEncrypter.Decrypt(connectionString));


            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
