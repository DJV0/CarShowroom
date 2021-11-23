using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowroom.WebAPI.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime BeginningOfWork { get; set; }
        public DateTime EndingOfWork { get; set; }
        public int? CarId { get; set; }
        public CarDTO Car { get; set; }
        public IEnumerable<EmployeeDTO> Employees { get; set; }
        public IEnumerable<PartDTO> Parts { get; set; }
    }
}
