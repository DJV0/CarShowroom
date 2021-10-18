﻿using Carshowroom.DAL;
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
    public class EmployeeService: Service<Employee>, IEmployeeService
    {
        public EmployeeService(CarShowroomDbContext context) : base(context) { }
        public override Employee Get(int id)
        {
            return context.Employees
                .Include(e => e.OrderEmployees)
                .ThenInclude(oe => oe.Order)
                .ThenInclude(o => o.Car)
                .FirstOrDefault(e => e.Id == id);
        }
    }
}
