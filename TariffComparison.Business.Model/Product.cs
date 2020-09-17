using System.ComponentModel.DataAnnotations;

namespace TariffComparison.Business.Model
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        public string TariffName { get; set; }

        [Required(ErrorMessage = "Type is required")] 
        public string PackageType { get; set; }

        [Required(ErrorMessage = "Consumption value is required")]
        public int Consumption { get; set; }
        public double AnnualCost { get; set; }
    }
}
