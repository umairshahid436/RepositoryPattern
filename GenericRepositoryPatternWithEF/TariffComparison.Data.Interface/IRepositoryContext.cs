using Microsoft.EntityFrameworkCore;
using TariffComparison.Data.Model;

namespace TariffComparison.Data.Interface
{
    public interface IRepositoryContext:IDbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
