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

        public string GetString(string key)
            => Configuration[key];

        public int GetInt(string key)
        {
            var value = Configuration[key];
            if (int.TryParse(value, out var result)) { return result; }

            throw new InvalidOperationException($"La clave '{key}' no contiene un valor entero válido.");
        }

        public bool GetBool(string key)
        {
            var value = Configuration[key];
            if (bool.TryParse(value, out var result)) { return result; }

            throw new InvalidOperationException($"La clave '{key}' no contiene un valor booleano válido.");
        }
    }
}
