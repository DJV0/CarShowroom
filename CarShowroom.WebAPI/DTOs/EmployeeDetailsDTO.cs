using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowroom.WebAPI.DTOs
{
    public class EmployeeDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }

        public IEnumerable<OrderDTO> Orders { get; set; }
    }
}
