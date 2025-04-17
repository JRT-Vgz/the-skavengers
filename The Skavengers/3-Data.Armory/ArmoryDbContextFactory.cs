
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
            var connectionString = "poVoGDbfQD6iXgUbZLyAkAeBw13dOa+274xt6kRTTwDO2nKy4WB4k81O1mmIOQK8buBs6D9HBggtnEt+BFjUbDHzcCFFA8We5L8w1H/ae4xFlbEihwFfAnhCrcO1ONM8kx6aH130+gZ00YjTLRH4C5KPN3erQPw+zNBG54qlCIOgs/8S9VDkzYc7PD9Fb618";

            var optionsBuilder = new DbContextOptionsBuilder<ArmoryDbContext>();
            optionsBuilder.UseSqlServer(DBEncrypter.Decrypt(connectionString));


            return new ArmoryDbContext(optionsBuilder.Options);
        }
    }
}
