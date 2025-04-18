using _1_Domain.CortezosWorkshop.Entities;
using _1_Domain.CortezosWorkshop.Interfaces;
using _1_Domain.TheSkavengers.Interfaces;
using _3_Data.CortezosWorkshop;
using _3_Data.CortezosWorkshop.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace _3___Repository
{
    public class GenericProductsRepository : IRepository<GenericProduct>
    {
        private readonly AppDbContext _context;
        private readonly IManualMapper<GenericProductModel,GenericProduct> _manualMapper;
        private readonly IMapper _mapper;
        public GenericProductsRepository(AppDbContext context,
            IManualMapper<GenericProductModel, GenericProduct> manualMapper,
            IMapper mapper)
        {
            _context = context;
            _manualMapper = manualMapper;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GenericProduct>> GetAllAsync()
            => await _context.GenericProducts.Include("Material").Select(p => _manualMapper.Map(p)).ToListAsync();

        public async Task<GenericProduct> GetByNameAsync(string name)
        {
            var genericProductModel = await _context.GenericProducts.Include("Material").AsNoTracking().FirstOrDefaultAsync(o => o.Name == name);

            return _manualMapper.Map(genericProductModel);
        }

        public async Task SaveChangesAsync()
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
