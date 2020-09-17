using TariffComparison.Business.Interface;
using TariffComparison.Infrastructure.Common;

namespace TariffComparison.Business.Service
{
    public class PackagedConsumptionCalculationService : IConsumptionCalculator
    {
        private const int BaseCost = 800;
        private const int ConsumptionLimit = 4000;
        private const int AdditionalCent = 30;
        public double Calculate(int Consumption)
        {
            if (Consumption <= ConsumptionLimit)
            {
                return BaseCost;
            }
            else
            {
                int Difference = Consumption - ConsumptionLimit;
                double TotalCost = (BaseCost + (Difference * AdditionalCent) / 100);
                return TotalCost;
            }
        }
        public bool Type(CustomEnum.CalculationModel type)
        {
            return CustomEnum.CalculationModel.Packaged.Equals(type);
        }
    }
}
