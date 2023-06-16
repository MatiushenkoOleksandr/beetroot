using Service.Repository.Entities;

namespace FinalProjectASP.Models
{
    public class ReservationModel
    {
        public Guid? Id { get; set; }
        public DateTime Date { get; set; }
        public int Hour { get; set; }
        public int Price { get; set; }
        public ReservationStatus Status { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public int PrepaidAmount { get; set; }
        public Guid CarId { get; set; }

    }
}
