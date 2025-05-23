using _1_Domain.CortezosWorkshop.Entities;
using _1_Domain.CortezosWorkshop.Interfaces;
using _3_Data.CortezosWorkshop;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace _3___Repository
{
    public class ShopStatsRepository : IRepository<ShopStat>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ShopStatsRepository(AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ShopStat>> GetAllAsync()
            => await _context.ShopStats.Select(s => _mapper.Map<ShopStat>(s)).AsNoTracking().ToListAsync();

        public async Task<ShopStat> GetByNameAsync(string name)
        {
            var shopStatsModel = await _context.ShopStats.AsNoTracking().FirstOrDefaultAsync(s => s.Name == name);

            return _mapper.Map<ShopStat>(shopStatsModel);
        }

        public async Task UpdateAsync(ShopStat shopStat)
        {
            var shopStatModel = await _context.ShopStats.FindAsync(shopStat.Id);

            _mapper.Map(shopStat, shopStatModel);

            _context.ShopStats.Attach(shopStatModel);
            _context.ShopStats.Entry(shopStatModel).State = EntityState.Modified;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
