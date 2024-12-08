using Microsoft.Extensions.Configuration;

namespace _2___Servicios.Services
{
    public class ConfigurationService
    {
        public IConfiguration Configuration { get; }
        public ConfigurationService()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.constants.json", optional: false, reloadOnChange: true)
                .Build();
        }
    }
}
