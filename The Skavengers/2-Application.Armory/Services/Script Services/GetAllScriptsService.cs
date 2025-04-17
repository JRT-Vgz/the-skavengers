
using _1_Domain.Armory.Entities;
using _1_Domain.Armory.Interfaces;

namespace _2_Application.Armory.Services.Script_Services
{
    public class GetAllScriptsService
    {
        private readonly IArmoryRepository<Script> _scriptRepository;

        public GetAllScriptsService(IArmoryRepository<Script> scriptRepository)
        {
            _scriptRepository = scriptRepository;
        }

        public async Task<IEnumerable<Script>> ExecuteAsync()
            => await _scriptRepository.GetAllAsync();
    }
}
