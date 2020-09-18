using System.Collections.Generic;
using System.Threading.Tasks;
using TariffComparison.Business.Model;

namespace TariffComparison.Business.Interface
{
    public interface IComparisonService
    {
        Task<List<ProductNameWithCost>> Comparison(int consumption);
    }
}
