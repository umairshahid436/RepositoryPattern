using BooteqPointOfSale.Business.Models.common;

namespace BooteqPointOfSale.Business.Model
{
    public class Worker : Address
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cnic { get; set; }
        public int Mobile { get; set; }
    }
}
