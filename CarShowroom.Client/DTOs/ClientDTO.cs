using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarShowroom.Client.DTOs
{
    public class ClientDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public ICollection<CarDTO> Cars { get; set; }
    }
}
