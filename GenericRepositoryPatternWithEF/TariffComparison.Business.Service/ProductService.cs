using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TariffComparison.Business.Interface;
using TariffComparison.Business.Model;
using TariffComparison.Data.Interface;
using TariffComparison.Infrastructure.Common;

namespace TariffComparison.Business.Service
{
    public class ProductService : GenericService<Data.Model.Product, Product, int>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private Func<CustomEnum.CalculationModel, IAnnualCostCalculator> _consumptionCalculatorDelegate;

        public ProductService(IMapper mapper, IProductRepository productRepository, IUnitOfWork unitOfWork, Func<CustomEnum.CalculationModel, IAnnualCostCalculator> consumptionCalculatorDelegate) : base(mapper, productRepository, unitOfWork)
        {
            _productRepository = productRepository;
            _consumptionCalculatorDelegate = consumptionCalculatorDelegate;
        }

        public async Task<List<ProductNameWithCost>> GetAllProducts()
        {
            var dataEntities = await _repository.Get();
            var businessEntities = _mapper.Map<List<Data.Model.Product>, List<Product>>(dataEntities);
            return await WrapData(businessEntities);
        }
        public async Task<List<ProductNameWithCost>> Comparison(int consumption)
        {
            // List to hold products
            List<Product> productList = new List<Product>();
            if (consumption > 0)
            {
                //Two products
                const string ProductA = "basic electricity tariff”";
                const string ProductB = "Packaged tariff";

                // Calculate annual cost
                double CostofProductA = _consumptionCalculatorDelegate(CustomEnum.CalculationModel.Basic).Calculate(consumption);
                double CostofProducctB = _consumptionCalculatorDelegate(CustomEnum.CalculationModel.Packaged).Calculate(consumption);

                productList.Add(new Product { AnnualCost = CostofProductA, TariffName = ProductA });
                productList.Add(new Product { AnnualCost = CostofProducctB, TariffName = ProductB });

                // Save data into database
                await _productRepository.Add(_mapper.Map<List<Product>, List<Data.Model.Product>>(productList));
                if (_unitOfWork != null)
                {
                    await _unitOfWork.SaveChangesAsync();
                }

            }
            return await WrapData(productList);
        }

        #region Private Methods
        private async Task<List<ProductNameWithCost>> WrapData(List<Product> products)
        {
            List<ProductNameWithCost> data = new List<ProductNameWithCost>();
            if (products.Count > 0)
            {
                foreach (var item in products)
                {
                    data.Add(new ProductNameWithCost()
                    {
                        TariffName = item.TariffName,
                        AnnualCost = $"{item.AnnualCost} €/Year"
                    });
                }
            }
            return await Task.Run(() => data);
        }
        #endregion
    }
}
