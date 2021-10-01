using System;

namespace CarShowroom.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime BeginningOfWork { get; set; }
        public DateTime EndingOfWork { get; set; }
    }
}
