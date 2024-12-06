
using _1___Entities;
using _2___Servicios.Interfaces;
using _3___Data;
using Microsoft.EntityFrameworkCore;

namespace _3___Repository
{
    public class ShopStatsRepository : IRepository<ShopStat>
    {
        private readonly AppDbContext _context;
        public ShopStatsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ShopStat>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ShopStat> GetByIdAsync(int id)
        {
            var shopStatModel = await _context.ShopStats.FindAsync(id);

            return new ShopStat
            {
                Name = shopStatModel.Name,
                Quantity = shopStatModel.Quantity
            };
        }

        public async Task UpdateAsync(ShopStat shopStat, int id)
        {
            var shopStatModel = await _context.ShopStats.FindAsync(id);

            shopStatModel.Name = shopStat.Name;
            shopStatModel.Quantity = shopStat.Quantity;

            _context.ShopStats.Attach(shopStatModel);
            _context.ShopStats.Entry(shopStatModel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
