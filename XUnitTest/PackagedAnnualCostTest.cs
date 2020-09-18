using TariffComparison.Business.Service;
using Xunit;

namespace XUnitTest
{
    public class PackagedAnnualCostTest
    {
        private PackagedAnnualCostCalculationService _service;
        public PackagedAnnualCostTest()
        {
            _service = new PackagedAnnualCostCalculationService();
        }
        [Fact]
        public void BasicCal3500()
        {
            Assert.Equal(800, _service.Calculate(3500), 0);
        }
        [Fact]
        public void BasicCal4500()
        {
            Assert.Equal(950, _service.Calculate(4500), 0);

        }
        [Fact]
        public void BasicCal6000()
        {
            Assert.Equal(1400, _service.Calculate(6000), 0);
        }
    }
}
