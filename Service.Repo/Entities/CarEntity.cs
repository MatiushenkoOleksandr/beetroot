using Service.Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Servis.Repository.Entities
{
    public class CarEntity : IEntity<Guid>
    {
        public string Vin { get; set; }
        public int Milage { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public FuelType FuelType { get; set; }

        public Guid ClientId { get; set; }
        public Guid Id { get; set; }
        [ForeignKey("ClientId")]
        public virtual CustomerEntity Owner { get; set; }
        public virtual ICollection<ReservationEntity> Reservations { get; set; }
    }
    public enum FuelType
    {
        Petrol,
        Diesel,
        LPG,
        Hybrid,
        Electric
    }

}
