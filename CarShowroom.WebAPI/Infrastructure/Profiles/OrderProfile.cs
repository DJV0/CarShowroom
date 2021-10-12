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
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>();
            CreateMap<Order, OrderDetailsDTO>()
                .ForMember(dest => dest.Employees, opt => opt.MapFrom(src => src.OrderEmployees.Select(oe => oe.Employee)))
                .ForMember(dest => dest.Parts, opt => opt.MapFrom(src => src.OrderParts.Select(op => op.Part)));
            CreateMap<OrderDetailsDTO, Order>()
                .ForMember(order=>order.Car, opt=>opt.Ignore())
                .ForMember(order => order.OrderEmployees, opt => opt
                     .MapFrom(orderDto => orderDto.Employees.Select(e => new OrderEmployee { EmployeeId = e.Id })))
                .ForMember(order => order.OrderParts, opt => opt
                      .MapFrom(orderDto => orderDto.Parts.Select(e => new OrderPart { PartId = e.Id })));
        }
    }
}
