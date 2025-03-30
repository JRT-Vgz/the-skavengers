
using _2___Servicios.Interfaces;

namespace _2___Servicios.Services.ArmoryServices
{
    public class CreateAutoEquipScriptTemplateService<TDto>
    {
        private readonly IPresenter<TDto, string> _presenter;
        public CreateAutoEquipScriptTemplateService(IPresenter<TDto, string> presenter)
        {
            _presenter = presenter;
        }

        public string Execute(TDto playerArmoryDataDto)
        {
            return _presenter.Present(playerArmoryDataDto);
        }
    }
}
