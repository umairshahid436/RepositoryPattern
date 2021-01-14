using Microsoft.EntityFrameworkCore;
using TariffComparison.Data.Interface;
using TariffComparison.Data.Model;

namespace TariffComparison.Data.Repository
{
    public class RepositoryContext: DbContext, IRepositoryContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        { }
        public DbSet<Product> Products { get; set; }

    }
}
