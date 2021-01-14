using System.Threading.Tasks;

namespace TariffComparison.Data.Interface
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();

    }
}
