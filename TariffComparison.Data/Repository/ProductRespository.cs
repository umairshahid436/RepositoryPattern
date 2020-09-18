using TariffComparison.Data.Interface;
using TariffComparison.Data.Model;

namespace TariffComparison.Data.Repository
{
    public class ProductRespository : GenericRespository<Product, int>, IProductRepository
    {
        private readonly IRepositoryContext _context;

        public ProductRespository(IRepositoryContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }


    }
}
