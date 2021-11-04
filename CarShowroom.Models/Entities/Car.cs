using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Models.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public DateTime Year { get; set; }
        public string BodyStyle { get; set; }
        public string Color { get; set; }
        public int Mileage { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Order> Orders { get; set; }

        public int? ClientId { get; set; }
        public Client Client { get; set; }
    }
}
