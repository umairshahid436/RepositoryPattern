using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TariffComparison.Business.Interface;
using TariffComparison.Business.Model;
using TariffComparison.Model;

namespace TariffComparison.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    public class ProductController : GenericController<Product, Data.Model.Product, int>
    {
        private readonly IProductService _productService;
        private readonly IComparisonService _comparisonService;

        public ProductController(IProductService productService, IComparisonService comparisonService) : base(productService)
        {
            _productService = productService;
            _comparisonService = comparisonService;
        }
        [HttpGet]
        public override async Task<ObjectResult> Get()
        {
            try
            {
                var products = await _productService.Get();
                return new OkObjectResult(BaseModel.Create(success: true, data: products, total: products.Count, message: "success"));
            }
            catch (Exception ex)
            {
                return new NotFoundObjectResult(BaseModel.Create(success: false, data: null, total: 0, message: ex.Message));
            }
        }

        [HttpGet("Comparison")]
        public async Task<ObjectResult> Comparison([FromQuery] int consumption)
        {
            try
            {
                var data = await _comparisonService.Comparison(consumption);
                return new OkObjectResult(BaseModel.Create(success: true, data, total: data.Count, message: "success"));
            }
            catch (Exception ex)
            {
                return new NotFoundObjectResult(BaseModel.Create(success: false, data: null, total: 0, message: ex.Message));
            }
        }

    }
}