﻿using System;

namespace CarShowroom.WebAPI.DTOs
{
    public class CarDTO
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public DateTime Year { get; set; }
        public string BodyStyle { get; set; }
        public string Color { get; set; }

        public int? ClientId { get; set; }
    }
}