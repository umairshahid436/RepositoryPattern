using TariffComparison.Business.Service;
using Xunit;

namespace XUnitTest
{
    public class BasicAnnualCostTest
    {
        private BasicAnnualCostCalculationService _service;
        public BasicAnnualCostTest()
        {
            _service = new BasicAnnualCostCalculationService();
        }

        [Fact]
        public void BasicCal3500()
        {
            Assert.Equal(830, _service.Calculate(3500), 0);
        }
        [Fact]
        public void BasicCal4500()
        {
            Assert.Equal(1050, _service.Calculate(4500), 0);
        }
        [Fact]
        public void BasicCal6000()
        {
            Assert.Equal(1380, _service.Calculate(6000), 0);
        }
    }
}
