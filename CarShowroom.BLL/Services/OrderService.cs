﻿using AutoMapper;
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
        public override IEnumerable<Order> GetAll()
        {
            return context.Orders.Include(o=>o.Car);
        }
        public override Order Get(int id)
        {
            var order = context.Orders
                .Include(o => o.Car)
                .Include(o => o.OrderEmployees)
                .ThenInclude(oe=>oe.Employee)
                .Include(o => o.OrderParts)
                .ThenInclude(oe => oe.Part)
                .FirstOrDefault(o => o.Id == id);
            if (order == null) throw new ItemNotFoundException($"{typeof(Order).Name} item with id {id} not found.");
            return order;
        }
        public override void Update(Order entity)
        {
            var order = Get(entity.Id);
            _mapper.Map(entity, order);
            base.Update(order);
        }
    }
}
