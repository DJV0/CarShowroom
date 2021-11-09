using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Models.Entities
{
    public class OrderEmployee
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
