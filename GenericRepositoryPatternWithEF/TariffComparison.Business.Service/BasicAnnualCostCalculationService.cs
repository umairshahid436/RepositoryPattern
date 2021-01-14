using TariffComparison.Business.Interface;
using TariffComparison.Infrastructure.Common;

namespace TariffComparison.Business.Service
{
    public class BasicAnnualCostCalculationService : IAnnualCostCalculator
    {
        private const int BaseCostPerMonth = 5;
        private const int NoOfMonths = 12;
        private const int Cent = 22;
        public double Calculate(int Consumption)
        {
            double TotalCost = ((BaseCostPerMonth * NoOfMonths) + ((Consumption * Cent)/100));
            return TotalCost;
        }
        public bool Type(CustomEnum.CalculationModel type)
        {
            return CustomEnum.CalculationModel.Packaged.Equals(type);
        }
    }
}
