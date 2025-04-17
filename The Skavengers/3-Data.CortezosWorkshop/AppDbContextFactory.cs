
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using _3_Encrypters.TheSkavengers;

namespace _3_Data.CortezosWorkshop
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            //var connectionString = "Encripted string";
            var connectionString = "";

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(DBEncrypter.Decrypt(connectionString));


            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
