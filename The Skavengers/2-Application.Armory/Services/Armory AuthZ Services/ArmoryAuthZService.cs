
using _1_Domain.Armory.Interfaces;

namespace _2_Application.Armory.Services.Armory_AuthZ_Services
{
    public class ArmoryAuthZService
    {
        private readonly IAuthZSystem _authorizationSystem;

        public ArmoryAuthZService(IAuthZSystem authorizationSystem)
        {
            _authorizationSystem = authorizationSystem;
        }

        public bool Execute(string password)
        {
            return _authorizationSystem.Authorize(password);
        }
    }
}
