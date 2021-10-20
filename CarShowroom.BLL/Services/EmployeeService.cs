using Carshowroom.DAL;
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
    public class EmployeeService: Service<Employee>, IEmployeeService
    {
        public EmployeeService(CarShowroomDbContext context) : base(context) { }
        public override async Task<Employee> GetAsync(int id)
        {
            var employee = await context.Employees
                .Include(e => e.OrderEmployees)
                .ThenInclude(oe => oe.Order)
                .ThenInclude(o => o.Car)
                .FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null) throw new ItemNotFoundException($"{typeof(Employee).Name} item with id {id} not found.");
            return employee;
        }
    }
}
