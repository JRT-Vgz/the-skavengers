

using _1_Domain.Armory.Entities;
using _1_Domain.Armory.Interfaces;
using _2_Application.Armory.Exceptions;
using AutoMapper;

namespace _2_Application.Armory.Services.Script_Services
{
    public class AddScriptService<TDto>
    {
        private readonly IArmoryRepository<Script> _armorRepository;
        private readonly IAuthNSystem _armoryAuthNSystem;
        private readonly IFormValidator<TDto> _formValidator;
        private readonly IEntityValidator<Script> _entityValidator;
        private readonly IMapper _mapper;

        public AddScriptService(IArmoryRepository<Script> armorRepository,
            IAuthNSystem armoryAuthNSystem,
            IFormValidator<TDto> formValidator,
            IEntityValidator<Script> entityValidator,
            IMapper mapper)
        {
            _armorRepository = armorRepository;
            _armoryAuthNSystem = armoryAuthNSystem;
            _formValidator = formValidator;
            _entityValidator = entityValidator;
            _mapper = mapper;
        }

        public async Task ExecuteAsync(TDto scriptDto, string password)
        {
            bool validForm = _formValidator.Validate(scriptDto);
            if (!validForm) { throw new FormValidationException(_formValidator.Error); }

            bool validAuthN = _armoryAuthNSystem.Authorize(password);
            if (!validAuthN) { throw new AuthNValidationException(_armoryAuthNSystem.InvalidAuthNMessage); }

            var script = _mapper.Map<Script>(scriptDto);

            bool validEntity = await _entityValidator.ValidateAddEntityAsync(script);
            if (!validEntity) { throw new EntityValidationException(_entityValidator.Error); }

            await _armorRepository.AddAsync(script);
        }
    }
}
