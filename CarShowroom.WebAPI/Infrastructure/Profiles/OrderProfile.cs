using AutoMapper;
using CarShowroom.Models.Entities;
using CarShowroom.WebAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowroom.WebAPI.Infrastructure.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, Order>().ForMember(dest=>dest.Car, opt=>opt.Ignore());
            CreateMap<Order, OrderDTO>()
                .ForMember(orderDto => orderDto.Employees, opt => opt
                    .MapFrom(order => order.OrderEmployees.Select(oe => oe.Employee)))
                .ForMember(orderDto => orderDto.Parts, opt => opt.MapFrom(order => order.OrderParts.Select(op => op.Part)));
            CreateMap<OrderDTO, Order>()
                .ForMember(order=>order.Car, opt=>opt.Ignore())
                .ForMember(order => order.OrderEmployees, opt => opt
                     .MapFrom(orderDto => orderDto.Employees.Select(e => new OrderEmployee { EmployeeId = e.Id })))
                .ForMember(order => order.OrderParts, opt => opt
                      .MapFrom(orderDto => orderDto.Parts.Select(e => new OrderPart { PartId = e.Id })));
        }
    }
}
