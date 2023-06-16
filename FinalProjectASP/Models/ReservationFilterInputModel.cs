using Service.Repository.Entities;

namespace FinalProjectASP.Models
{
    public class ReservationFilterInputModel
    {
       
        public DateTime? Date { get; set; }
        public int? HourFrom { get; set; }
        public int? HourTo { get; set; }
        public ReservationStatus? Status { get; set; }
        public PaymentStatus? PaymentStatus { get; set; }
        public Guid? CarId { get; set; }



    }
}
