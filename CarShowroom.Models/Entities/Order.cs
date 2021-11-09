using System;
using System.Collections.Generic;

namespace CarShowroom.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime BeginningOfWork { get; set; }
        public DateTime EndingOfWork { get; set; }

        public int? CarId { get; set; }
        public Car Car { get; set; }

        public ICollection<OrderEmployee> OrderEmployees { get; set; }
        public ICollection<OrderPart> OrderParts { get; set; }

    }
}
