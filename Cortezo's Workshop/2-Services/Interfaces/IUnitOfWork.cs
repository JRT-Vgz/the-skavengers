
using _1___Entities;

namespace _2___Servicios.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<IngotResource> IngotResources { get; }
        public IRepository<GenericProduct> GenericProducts { get; }
        public IRepository<ShopStat> ShopStats { get; }

        public Task SaveChangesAsync();
    }
}
