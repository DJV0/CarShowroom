using Carshowroom.DAL;
using CarShowroom.BLL.Interfaces;
using CarShowroom.Models.Entities;
using Microsoft.EntityFrameworkCore;
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
        public override Car Get(int id)
        {
            return context.Cars
                .Include(c => c.Client)
                .Include(c => c.Order)
                .FirstOrDefault(c => c.Id == id);
        }
    }
}
