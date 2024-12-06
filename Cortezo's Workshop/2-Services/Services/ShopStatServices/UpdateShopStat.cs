
using _1___Entities;
using _2___Servicios.Interfaces;
using AutoMapper;

namespace _2___Servicios.Services.ShopStatServices
{
    public class UpdateShopStat<TUpdateDto>
    {
        private readonly IRepository<ShopStat> _shopStatsRepository;
        private readonly IMapper _mapper;

        public UpdateShopStat(IRepository<ShopStat> shopStatsRepository, 
            IMapper mapper)
        {
            _shopStatsRepository = shopStatsRepository;
            _mapper = mapper;
        }

        public async Task ExecuteAsync(TUpdateDto updateDto, int id)
        {
            var shopStat = _mapper.Map<ShopStat>(updateDto);

            await _shopStatsRepository.UpdateAsync(shopStat, id);
        }
    }
}
