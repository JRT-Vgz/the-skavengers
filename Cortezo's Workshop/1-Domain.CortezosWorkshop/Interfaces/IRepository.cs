
namespace _1_Domain.CortezosWorkshop.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByNameAsync(string name);
        Task UpdateAsync(TEntity entity);
        Task SaveChangesAsync();
    }
}
