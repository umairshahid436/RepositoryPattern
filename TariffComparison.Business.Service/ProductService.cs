using AutoMapper;
using System;
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

        public override async Task<Product> Add(Product model)
        {
            CustomEnum.CalculationModel type = Utills.ParseEnum<CustomEnum.CalculationModel>(model.PackageType);
            IAnnualCostCalculator consCal = _consumptionCalculatorDelegate(type);
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


    }
}
