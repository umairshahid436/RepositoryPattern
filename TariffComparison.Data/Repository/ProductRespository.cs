using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public override async Task<List<Product>> Get()
        {
            return await _context.Products.AsQueryable().OrderBy(x=>x.AnnualCost).ToListAsync();
        }

    }
}
