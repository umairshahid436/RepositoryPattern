using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TariffComparison.Data.Interface
{
    public interface IGenericRepository<TEntity, TKey>
    {
        Task<List<TEntity>> Get();
        Task<TEntity> Add(TEntity entity);
        

    }
}
