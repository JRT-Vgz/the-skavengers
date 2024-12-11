
using _1___Entities;
using _2___Servicios.Interfaces;
using _3___Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace _3___Repository
{
    public class CommoditiesRepository : IRepository<Commodity>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CommoditiesRepository(AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Commodity>> GetAllAsync()
            => await _context.Commodities.Select(c => _mapper.Map<Commodity>(c)).ToListAsync();

        public async Task<Commodity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Commodity> GetByNameAsync(string name)
        {
            var commodityModel = await _context.Commodities.FirstOrDefaultAsync(o => o.Name == name);

            return _mapper.Map<Commodity>(commodityModel);
        }

        public async Task SaveChanges()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Commodity entity)
        {
            throw new NotImplementedException();
        }
    }
}
