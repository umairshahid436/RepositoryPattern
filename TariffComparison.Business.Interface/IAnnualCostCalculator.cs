using TariffComparison.Infrastructure.Common;

namespace TariffComparison.Business.Interface
{
    public interface IAnnualCostCalculator
    {
        bool Type(CustomEnum.CalculationModel type);
        double Calculate(int Consumption);
    }
}
