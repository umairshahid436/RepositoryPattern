using System.Collections.Generic;
using System.Threading.Tasks;
using TariffComparison.Business.Model;

namespace TariffComparison.Business.Interface
{
    public interface IProductService : IGenericService<Product, Data.Model.Product, int>
    {
        Task<List<ProductNameWithCost>> GetAllProducts();
        Task<List<ProductNameWithCost>> Comparison(int consumption);
    }
}
