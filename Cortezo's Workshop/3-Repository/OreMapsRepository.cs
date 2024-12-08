using _1___Entities;
using _2___Servicios.Interfaces;
using _3___Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace _3___Repository
{
    public class OreMapsRepository : IRepository<OreMap>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public OreMapsRepository(AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OreMap>> GetAllAsync()
            => await _context.OreMaps.Select(o => _mapper.Map<OreMap>(o)).ToListAsync();

        public async Task<OreMap> GetByIdAsync(int id)
        {
            var oreMapModel = await _context.OreMaps.FindAsync(id);

            return _mapper.Map<OreMap>(oreMapModel);
        }

        public async Task<OreMap> GetByNameAsync(string name)
        {
            var oreMapModel = await _context.OreMaps.FirstOrDefaultAsync(o => o.Name == name);

            return _mapper.Map<OreMap>(oreMapModel);
        }

        public async Task UpdateAsync(OreMap oreMap)
        {
            var oreMapModel = await _context.OreMaps.FindAsync(oreMap.Id);

            _mapper.Map(oreMap, oreMapModel);

            _context.OreMaps.Attach(oreMapModel);
            _context.OreMaps.Entry(oreMapModel).State = EntityState.Modified;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
