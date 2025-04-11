using _1_Domain.CortezosWorkshop.Entities;
using _1_Domain.CortezosWorkshop.Interfaces;
using _1_Domain.TheSkavengers.Interfaces;
using _2_Application.TheSkavengers.Services;
using _3_Data.CortezosWorkshop;
using _3_Data.CortezosWorkshop.Models;
using AutoMapper;

namespace _3___Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IRepository<IngotResource> _ingotResourcesRepository;
        private IRepository<GenericProduct> _genericProductsRepository;
        private IRepository<ShopStat> _shopStatRepository;
        private readonly IMapper _mapper;
        private readonly IManualMapper<GenericProductModel, GenericProduct> _manualMapper;
        private readonly ConstantsConfigurationService _configuration;

        public IRepository<IngotResource> IngotResources 
        {
            get
            {
                return _ingotResourcesRepository == null ? 
                    _ingotResourcesRepository = new IngotResourcesRepository(_context, _mapper) :
                    _ingotResourcesRepository;
            }
        }
        public IRepository<GenericProduct> GenericProducts
        {
            get
            {
                return _genericProductsRepository == null ?
                    _genericProductsRepository = new GenericProductsRepository(_context, _manualMapper, _mapper) :
                    _genericProductsRepository;
            }
        }
        public IRepository<ShopStat> ShopStats
        {
            get
            {
                return _shopStatRepository == null ?
                    _shopStatRepository = new ShopStatsRepository(_context, _mapper) :
                    _shopStatRepository;
            }
        }

        public UnitOfWork(AppDbContext context, IMapper mapper, IManualMapper<GenericProductModel, GenericProduct> manualMapper,
            ConstantsConfigurationService configuration)
        {
            _context = context;
            _mapper = mapper;
            _manualMapper = manualMapper;
            _configuration = configuration;
        }

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}
