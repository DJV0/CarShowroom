using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Models.Entities
{
    public class Part
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }

        public ICollection<OrderPart> OrderParts { get; set; }
    }
}
