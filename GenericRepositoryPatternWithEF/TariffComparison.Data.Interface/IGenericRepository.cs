using System.Collections.Generic;
using System.Threading.Tasks;

namespace TariffComparison.Data.Interface
{
    public interface IGenericRepository<TEntity, TKey>
    {
        Task<List<TEntity>> Get();
        Task<TEntity> Add(TEntity entity);
        Task Add(List<TEntity> entities);


    }
}
