
using _1___Entities;
using _2___Servicios.Interfaces;
using _3___Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace _3___Repository
{
    public class IngotResourcesRepository : IRepository<IngotResource>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public IngotResourcesRepository(AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<IngotResource>> GetAllAsync()
            => await _context.IngotResources.Include("Material").Select(i => _mapper.Map<IngotResource>(i))
            .AsNoTracking().ToListAsync();

        public async Task<IngotResource> GetByNameAsync(string ingotName)
        {
            var ingotResourceModel = await _context.IngotResources.AsNoTracking().FirstOrDefaultAsync(o => o.ResourceName == ingotName);

            return _mapper.Map<IngotResource>(ingotResourceModel);
        }

        public async Task UpdateAsync(IngotResource ingotResource)
        {
            var ingotResourceModel = await _context.IngotResources.FindAsync(ingotResource.Id);

            _mapper.Map(ingotResource, ingotResourceModel);
           
            _context.IngotResources.Attach(ingotResourceModel);
            _context.IngotResources.Entry(ingotResourceModel).State = EntityState.Modified;
        }

        public async Task SaveChanges()
        { 
            await _context.SaveChangesAsync();
        }
    }
}
