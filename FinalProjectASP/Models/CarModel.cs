using Servis.Repository.Entities;

namespace FinalProjectASP.Models
{
    public class CarModel
    {
        public string Vin { get; set; }
        public Guid ClientId { get; set; }
        public Guid? Id { get; set; }
        public int Milage { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public FuelType FuelType { get; set; }
    }
}
