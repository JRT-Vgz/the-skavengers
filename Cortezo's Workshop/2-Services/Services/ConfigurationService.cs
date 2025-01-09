using Microsoft.Extensions.Configuration;

namespace _2___Servicios.Services
{
    public class ConfigurationService
    {
        public IConfiguration Configuration { get; }
        private const string _CONSTANTS_FILE_NAME = "appsettings.constants.json";

        public ConfigurationService()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($@"Resources\AppSettings\{_CONSTANTS_FILE_NAME}", optional: false, reloadOnChange: true)
                .Build();
        }
    }
}
