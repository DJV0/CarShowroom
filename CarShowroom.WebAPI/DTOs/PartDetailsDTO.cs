using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowroom.WebAPI.DTOs
{
    public class PartDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }

        public IEnumerable<OrderDTO> Orders { get; set; }
    }
}
