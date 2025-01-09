
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using _3_Encrypters;

namespace _3___Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var connectionString = "Connection string";
            //var connectionString = "";

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(DBEncrypter.Decrypt(connectionString));


            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
