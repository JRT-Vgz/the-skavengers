
using _1___Entities;
using _2___Servicios.Interfaces;
using _3___Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace _3___Repository
{
    public class IngotsRepository : IRepository<Ingot>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public IngotsRepository(AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Ingot>> GetAllAsync()
            => await _context.Ingots.Select(i => _mapper.Map<Ingot>(i)).ToListAsync();

        public Task<Ingot> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Ingot> GetByNameAsync(string name)
        {
            var ingotModel = await _context.Ingots.FirstOrDefaultAsync(o => o.Name == name);

            return _mapper.Map<Ingot>(ingotModel);
        }

        public Task SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Ingot entity)
        {
            throw new NotImplementedException();
        }
    }
}
