
using _1_Domain.Armory.Entities;
using _1_Domain.Armory.Interfaces;

namespace _2_Application.Armory.Services.Script_Services
{
    public class DeleteScriptService
    {
        private readonly IArmoryRepository<Script> _armorRepository;

        public DeleteScriptService(IArmoryRepository<Script> armorRepository)
        {
            _armorRepository = armorRepository;
        }

        public async Task ExecuteAsync(Script script)
        {
            await _armorRepository.DeleteAsync(script);
        }
    }
}
