using _1_Domain.CortezosWorkshop.Entities;

namespace _1_Domain.CortezosWorkshop.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<IngotResource> IngotResources { get; }
        public IRepository<GenericProduct> GenericProducts { get; }
        public IRepository<ShopStat> ShopStats { get; }

        public Task SaveChangesAsync();
    }
}
