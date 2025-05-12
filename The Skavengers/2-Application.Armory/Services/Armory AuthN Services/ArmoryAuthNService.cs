
using _1_Domain.Armory.Interfaces;

namespace _2_Application.Armory.Services.Armory_AuthN_Services
{
    public class ArmoryAuthNService
    {
        private readonly IAuthNSystem _authenticationSystem;
        public string invalidAuthNMessage;

        public ArmoryAuthNService(IAuthNSystem authenticationSystem)
        {
            _authenticationSystem = authenticationSystem;
        }

        public bool Execute(string password)
        {
            invalidAuthNMessage = _authenticationSystem.InvalidAuthNMessage;
            return _authenticationSystem.Authorize(password);
        }
    }
}
