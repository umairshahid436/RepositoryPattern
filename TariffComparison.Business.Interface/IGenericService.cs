using System.Collections.Generic;
using System.Threading.Tasks;

namespace TariffComparison.Business.Interface
{
    public interface IGenericService<TBusinessModel, TDataModel, TKey>
    {
        Task<List<TBusinessModel>> Get();
        Task<TBusinessModel> Add(TBusinessModel entity);
        Task Add(List<TBusinessModel> businessEntities);
    }
}
