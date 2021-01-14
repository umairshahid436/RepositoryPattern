namespace BooteqPointOfSale.Data.Models
{
    public class Worker : Address
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cnic { get; set; }
        public int Mobile { get; set; }

    }
}
