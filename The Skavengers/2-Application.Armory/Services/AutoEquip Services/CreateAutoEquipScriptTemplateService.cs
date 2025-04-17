
using _1_Domain.TheSkavengers.Interfaces;

namespace _2_Application.Armory.Services.AutoEquip_Services
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
