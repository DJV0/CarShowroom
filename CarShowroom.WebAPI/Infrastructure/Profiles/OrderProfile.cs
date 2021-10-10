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
        }
    }
}
