using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson13
{
    public class Suspention
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public SuspentionParts Type { get; set; }
    }
    public enum SuspentionParts
    {
        Coilover,
        Spring,
        SilentBlock,
        LayerSupport,

    }
}
