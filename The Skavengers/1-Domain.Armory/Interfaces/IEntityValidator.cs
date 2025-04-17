
using System.Threading.Tasks;

namespace _1_Domain.Armory.Interfaces
{
    public interface IEntityValidator<TEntity>
    {
        public string Error { get; set; }
        Task<bool> ValidateAddEntityAsync(TEntity entity);
        Task<bool> ValidateUpdateEntityAsync(TEntity entity);
    }
}
