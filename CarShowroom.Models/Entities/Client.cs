using System.Collections.Generic;

namespace CarShowroom.Models.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
