namespace TariffComparison.Data.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string TariffName { get; set; }
        public string PackageType { get; set; }
        public string Unit { get; set; } = "KWh";
        public int Consumption { get; set; }
        public double AnnualCost { get; set; }
    }
}
