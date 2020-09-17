using TariffComparison.Infrastructure.Common;

namespace TariffComparison.Business.Interface
{
    public interface IConsumptionCalculator
    {
        bool Type(CustomEnum.CalculationModel type);
        double Calculate(int Consumption);
    }
}
