using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Models
{
    public class OrderPart
    {
        public int? OrderId { get; set; }
        public Order Order { get; set; }

        public int PartId { get; set; }
        public Part Part { get; set; }
    }
}
