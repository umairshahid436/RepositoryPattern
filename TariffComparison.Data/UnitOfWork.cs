using System.Threading.Tasks;
using TariffComparison.Data.Interface;

namespace TariffComparison.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext dbContext;

        public UnitOfWork(IDbContext context)
        {
            dbContext = context;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}
