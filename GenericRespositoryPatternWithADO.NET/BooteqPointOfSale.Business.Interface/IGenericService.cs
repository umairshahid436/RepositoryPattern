using System.Collections.Generic;

namespace BooteqPointOfSale.Business.Interface
{
    public interface IGenericService<TEntity, TKey>
    {
        List<TEntity> Get();
    }
}
