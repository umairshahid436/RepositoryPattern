using System.Collections.Generic;

namespace BooteqPointOfSale.Data.Interfaces
{
    public interface IGenericRepository<TEntity, TKey>
    {
        List<TEntity> Get();
    }
}
