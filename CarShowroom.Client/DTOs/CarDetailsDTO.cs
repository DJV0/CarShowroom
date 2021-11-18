using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowroom.Client.DTOs
{
    public class CarDetailsDTO
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public string BodyStyle { get; set; }
        public string Color { get; set; }
        public string ImageUrl { get; set; }

        public IEnumerable<OrderDTO> Orders { get; set; }

        public int? ClientId { get; set; }
        public ClientDTO Client { get; set; }
    }
}
