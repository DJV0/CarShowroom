using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowroom.Client.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BeginningOfWork { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndingOfWork { get; set; }
        [Required]
        public int? CarId { get; set; }
        public CarDTO Car { get; set; }
        public ICollection<EmployeeDTO> Employees { get; set; }
        public ICollection<PartDTO> Parts { get; set; }
    }
}
