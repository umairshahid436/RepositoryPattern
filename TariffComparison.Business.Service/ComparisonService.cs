using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TariffComparison.Business.Interface;
using TariffComparison.Business.Model;
using TariffComparison.Infrastructure.Common;

namespace TariffComparison.Business.Service
{
    public class ComparisonService : IComparisonService
    {
        private Func<CustomEnum.CalculationModel, IAnnualCostCalculator> _consumptionCalculatorDelegate;
        public ComparisonService(Func<CustomEnum.CalculationModel, IAnnualCostCalculator> consumptionCalculatorDelegate)
        {
            _consumptionCalculatorDelegate = consumptionCalculatorDelegate;
        }
        public Task<List<ProductNameWithCost>> Comparison(int consumption)
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

                // Sort list by annual cost in ascending order
                productList = productList.OrderBy(x => x.AnnualCost).ToList();
            }
            return WrapData(productList);
        }


        #region private methods 
        private Task<List<ProductNameWithCost>> WrapData(List<Product> products)
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
            return Task.Run(() => data);

        }


        #endregion
    }
}
