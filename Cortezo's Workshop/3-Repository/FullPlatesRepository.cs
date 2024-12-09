
using _1___Entities;
using _1___Entities.ProductEntities;
using _2___Servicios.Interfaces;
using _3___Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace _3___Repository
{
    public class FullPlatesRepository : IRepository<FullPlate>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public FullPlatesRepository(AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FullPlate>> GetAllAsync()
            => await _context.FullPlates.Select(f => _mapper.Map<FullPlate>(f)).ToListAsync();

        public async Task<FullPlate> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<FullPlate> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChanges()
            => await _context.SaveChangesAsync();

        public async Task UpdateAsync(FullPlate fullPlate)
        {
            var fullPlateModel = await _context.FullPlates.FindAsync(fullPlate.Id);

            _mapper.Map(fullPlate, fullPlateModel);

            _context.FullPlates.Attach(fullPlateModel);
            _context.FullPlates.Entry(fullPlateModel).State = EntityState.Modified;
        }
    }
}
