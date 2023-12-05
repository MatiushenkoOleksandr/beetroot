using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Servis.Repository.Entities
{
    public class CarEntity : BaseEntity
    {
        public string Vin { get; set; }
        public Guid ClientId { get; set; }

    }
}
