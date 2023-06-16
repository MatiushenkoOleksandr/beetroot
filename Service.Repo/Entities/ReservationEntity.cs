using Servis.Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repository.Entities
{
    public class ReservationEntity : IEntity<Guid>
    {
        public Guid Id { get ; set; }
        public DateTime Date { get; set; }
        public int Hour { get; set; }
        public int Price { get; set; }
        public ReservationStatus Status { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public int PrepaidAmount { get; set; }
        public Guid CarId { get; set; }

        [ForeignKey("CarId")]
        public virtual CarEntity Car { get; set; }
    }
    public enum ReservationStatus
    {
        Completed,
        InProgress,
        WaitingForCustomer,
        JustArrived
    }
    public enum PaymentStatus
    {
        Paid,
        NotPaid,
        PartlyPaid

    }
}
