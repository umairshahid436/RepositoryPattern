using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        private Func<CustomEnum.CalculationModel, IConsumptionCalculator> _consumptionCalculatorDelegate;

        public ProductService(IMapper mapper, IProductRepository productRepository, IUnitOfWork unitOfWork, Func<CustomEnum.CalculationModel, IConsumptionCalculator> consumptionCalculatorDelegate) : base(mapper, productRepository, unitOfWork)
        {
            _productRepository = productRepository;
            _consumptionCalculatorDelegate = consumptionCalculatorDelegate;
        }
        public async Task<List<ProductWrap>> GetAll()
        {
            var dataEntities = await _productRepository.Get();
            var businessEntities = _mapper.Map<List<Data.Model.Product>, List<Product>>(dataEntities);
            List<ProductWrap> wrapData = WrapData(businessEntities);
            return wrapData;
        }
        public override async Task<Product> Add(Product model)
        {
            CustomEnum.CalculationModel type = Utills.ParseEnum<CustomEnum.CalculationModel>(model.PackageType);
            IConsumptionCalculator consCal = _consumptionCalculatorDelegate(type);
            double cost = consCal.Calculate(model.Consumption);
            model.AnnualCost = cost;
            var dataEntity = _mapper.Map<Product, Data.Model.Product>(model);

            dataEntity = await _productRepository.Add(dataEntity);
            if (_unitOfWork != null)
            {
                await _unitOfWork.SaveChangesAsync();
            }
            return _mapper.Map<Data.Model.Product, Product>(dataEntity);
        }

        #region private methods 
        private List<ProductWrap> WrapData(List<Product> products)
        {
            List<ProductWrap> data = new List<ProductWrap>();
            if (products.Count > 0)
            {
                foreach (var item in products)
                {
                    data.Add(new ProductWrap() { TariffName = item.TariffName, AnnualCost = $"{item.AnnualCost} €/Year" });
                }
            }
            return data;

        }
        #endregion
    }
}
