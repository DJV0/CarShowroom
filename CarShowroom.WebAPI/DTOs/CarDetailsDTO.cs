using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowroom.WebAPI.DTOs
{
    public class CarDetailsDTO
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public DateTime Year { get; set; }
        public string BodyStyle { get; set; }
        public string Color { get; set; }

        public int? OrderId { get; set; }
        public OrderDTO Order { get; set; }

        public int? ClientId { get; set; }
        public ClientDTO Client { get; set; }
    }
}
