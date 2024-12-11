
using _1___Entities;
using _2___Servicios.Interfaces;
using _3___Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace _3___Repository
{
    public class GenericProductsRepository : IRepository<GenericProduct>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public GenericProductsRepository(AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GenericProduct>> GetAllAsync()
            => await _context.GenericProducts.Include("Material").Select(p => _mapper.Map<GenericProduct>(p)).ToListAsync();

        public Task<GenericProduct> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<GenericProduct> GetByNameAsync(string name)
        {
            var genericProductModel = await _context.GenericProducts.FirstOrDefaultAsync(o => o.Name == name);

            return _mapper.Map<GenericProduct>(genericProductModel);
        }

        public async Task SaveChanges()
            => await _context.SaveChangesAsync();

        public async Task UpdateAsync(GenericProduct product)
        {
            var productModel = await _context.GenericProducts.FindAsync(product.Id);

            _mapper.Map(product, productModel);

            _context.GenericProducts.Attach(productModel);
            _context.GenericProducts.Entry(productModel).State = EntityState.Modified;
        }
    }
}
