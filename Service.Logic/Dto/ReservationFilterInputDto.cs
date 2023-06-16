using Service.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Logic.Dto
{
    public class ReservationFilterInputDto
    {
        public DateTime? Date { get; set; }
        public int? HourFrom { get; set; }
        public int? HourTo { get; set; }
        public ReservationStatus? Status { get; set; }
        public PaymentStatus? PaymentStatus { get; set; }
        public Guid? CarId { get; set; }
    }
}
