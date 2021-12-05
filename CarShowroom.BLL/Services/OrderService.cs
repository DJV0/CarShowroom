using AutoMapper;
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
    public class OrderService : Service<Order>, IOrderService
    {
        private readonly IMapper _mapper;
        public OrderService(CarShowroomDbContext context, IMapper mapper) : base(context) => _mapper = mapper;
        public override async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await context.Orders.Include(o=>o.Car).ToListAsync();
        }
        public override async Task<Order> GetByIdAsync(int id)
        {
            var order = await context.Orders
                .Include(o => o.Car)
                .Include(o => o.OrderEmployees)
                .ThenInclude(oe=>oe.Employee)
                .Include(o => o.OrderParts)
                .ThenInclude(oe => oe.Part)
                .FirstOrDefaultAsync(o => o.Id == id);
            if (order == null) throw new ItemNotFoundException($"{typeof(Order).Name} item with id {id} not found.");
            return order;
        }
        public override async Task UpdateAsync(Order entity)
        {
            var order = await GetByIdAsync(entity.Id);
            _mapper.Map(entity, order);
            await base.UpdateAsync(order);
        }
    }
}
