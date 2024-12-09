
using _1___Entities.ProductEntities;
using _2___Servicios.Interfaces;
using _3___Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace _3___Repository
{
    public class ToolsRepository : IRepository<Tool>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ToolsRepository(AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Tool>> GetAllAsync()
            => await _context.Tools.Select(t => _mapper.Map<Tool>(t)).ToListAsync();

        public async Task<Tool> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Tool> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChanges()
            => await _context.SaveChangesAsync();

        public async Task UpdateAsync(Tool tool)
        {
            var toolModel = await _context.Tools.FindAsync(tool.Id);

            _mapper.Map(tool, toolModel);

            _context.Tools.Attach(toolModel);
            _context.Tools.Entry(toolModel).State = EntityState.Modified;
        }
    }
}
