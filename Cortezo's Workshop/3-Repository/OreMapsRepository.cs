using _1___Entities;
using _2___Servicios.Interfaces;
using _3___Data;
using Microsoft.EntityFrameworkCore;

namespace _3___Repository
{
    public class OreMapsRepository : IRepository<OreMap>
    {
        private readonly AppDbContext _context;
        public OreMapsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OreMap>> GetAllAsync()
            => await _context.OreMaps.Select(o => new OreMap
            {
                Name = o.Name,
                Quantity = o.Quantity,
                TotalOre = o.TotalOre
            }).ToListAsync();

        public Task<OreMap> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(OreMap entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
