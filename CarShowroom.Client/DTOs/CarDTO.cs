using System;
using System.Collections.Generic;

namespace CarShowroom.Client.DTOs
{
    public class CarDTO
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public string BodyStyle { get; set; }
        public string Color { get; set; }
        public string ImageUrl { get; set; }
        public int? ClientId { get; set; }
    }
}
