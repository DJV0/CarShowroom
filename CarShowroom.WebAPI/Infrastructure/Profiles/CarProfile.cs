using AutoMapper;
using CarShowroom.Models.Entities;
using CarShowroom.WebAPI.DTOs;
using System;

namespace CarShowroom.WebAPI.Infrastructure.Profiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarDTO>().ForMember(carDto => carDto.Year, opt=>opt.MapFrom(car=>car.Year.Year));
            CreateMap<CarDTO, Car>().ForMember(car=>car.Year, opt=>opt.MapFrom(carDto=>new DateTime(carDto.Year,1,1)));
        }
    }
}
