
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using _3_Encrypters.TheSkavengers;

namespace _3_Data.Armory
{
    public class ArmoryDbContextFactory : IDesignTimeDbContextFactory<ArmoryDbContext>
    {
        public ArmoryDbContext CreateDbContext(string[] args)
        {
            //var connectionString = "Encripted string";
            var connectionString = "";

            var optionsBuilder = new DbContextOptionsBuilder<ArmoryDbContext>();
            optionsBuilder.UseSqlServer(DBEncrypter.Decrypt(connectionString));


            return new ArmoryDbContext(optionsBuilder.Options);
        }
    }
}
