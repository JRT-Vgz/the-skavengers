
namespace _1_Domain.Armory.Interfaces
{
    public interface IArmoryRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
