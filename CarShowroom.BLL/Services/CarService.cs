﻿using Carshowroom.DAL;
using CarShowroom.BLL.Exceptions;
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
        public override async Task<Car> GetAsync(int id)
        {
            var car = await context.Cars
                .Include(c => c.Client)
                .Include(c => c.Order)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (car == null) throw new ItemNotFoundException($"{typeof(Car).Name} item with id {id} not found.");
            return car;
        }
    }
}
