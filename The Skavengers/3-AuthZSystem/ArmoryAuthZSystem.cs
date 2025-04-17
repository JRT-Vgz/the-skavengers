using _1_Domain.Armory.Interfaces;
using _2_Application.TheSkavengers.Services;
using _3_Encrypters.TheSkavengers;

namespace _3_AuthZSystem.Armory
{
    public class ArmoryAuthZSystem : IAuthZSystem
    {
        private readonly ConstantsConfigurationService _configuration;

        public string InvalidAuthZMessage { get; } = "No has dicho la palabra mágica.";
        public ArmoryAuthZSystem(ConstantsConfigurationService configuration)
        {
            _configuration = configuration;
        }

        public bool Authorize(string password)
        {
            if (password == DBEncrypter.Decrypt(_configuration.GetString("Armory_Constants:_ARMORY_PASSWORD"))) { return true; }
            return false;
        }
    }
}
