using Carshowroom.DAL;
using CarShowroom.BLL.Interfaces;
using CarShowroom.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.BLL.Services
{
    public class CarService : Service<Car>, ICarService
    {
        public CarService(CarShowroomDbContext context) : base(context) { }
    }
}
