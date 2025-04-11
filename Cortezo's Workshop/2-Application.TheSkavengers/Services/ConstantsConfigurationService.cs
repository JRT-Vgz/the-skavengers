using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace _2_Application.TheSkavengers.Services
{
    public class ConstantsConfigurationService
    {
        public IConfiguration Configuration { get; }
        private const string _CONSTANTS_NAMESPACE = "_2_Application.TheSkavengers.Resources.ConstantsSettings";
        private const string _CONSTANTS_FILE_NAME = "appsettings.constants.json";

        public ConstantsConfigurationService()
        {
            Configuration = BuildConfiguration();
            
        }

        private IConfiguration BuildConfiguration()
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (var stream = assembly.GetManifestResourceStream($"{_CONSTANTS_NAMESPACE}.{_CONSTANTS_FILE_NAME}"))
            {
                if (stream == null)
                {
                    throw new FileNotFoundException("El archivo de configuración no se encuentra como recurso incrustado.");
                }

                var configuration = new ConfigurationBuilder()
                    .AddJsonStream(stream)
                    .Build();
                return configuration;
            }
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
