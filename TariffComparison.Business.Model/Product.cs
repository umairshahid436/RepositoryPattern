using System.ComponentModel.DataAnnotations;

namespace TariffComparison.Business.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string TariffName { get; set; }    
        public double AnnualCost { get; set; }
    }
}
