using AutoMapper;
using CarShowroom.Models.Entities;
using CarShowroom.WebAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowroom.WebAPI.Infrastructure.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeDTO, Employee>();
            CreateMap<Employee, EmployeeDetailsDTO>()
                .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.OrderEmployees.Select(oe=>oe.Order)));
        }
    }
}
