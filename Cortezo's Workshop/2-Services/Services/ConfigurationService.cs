using Microsoft.Extensions.Configuration;

namespace _2___Servicios.Services
{
    public class ConfigurationService
    {
        public IConfiguration Configuration { get; }
        public ConfigurationService()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // o especifica la ruta si es diferente
                .AddJsonFile("appsettings.constants.json", optional: false, reloadOnChange: true)
                .Build();
        }
    }
}
