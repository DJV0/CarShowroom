﻿using System.Collections.Generic;

namespace CarShowroom.Client.DTOs
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Phone { get; set; }
        public IEnumerable<CarDTO> Cars { get; set; }
    }
}
