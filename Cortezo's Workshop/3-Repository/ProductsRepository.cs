
using _1___Entities;
using _2___Servicios.Interfaces;
using _3___Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace _3___Repository
{
    public class ProductsRepository : IRepository<Product>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ProductsRepository(AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
            => await _context.Products.Include("Material").Select(p => _mapper.Map<Product>(p)).ToListAsync();

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChanges()
            => await _context.SaveChangesAsync();

        public async Task UpdateAsync(Product product)
        {
            var productModel = await _context.Products.FindAsync(product.Id);

            _mapper.Map(product, productModel);

            _context.Products.Attach(productModel);
            _context.Products.Entry(productModel).State = EntityState.Modified;
        }
    }
}
