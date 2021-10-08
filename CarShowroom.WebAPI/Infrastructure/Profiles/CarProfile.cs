using AutoMapper;
using CarShowroom.Models.Entities;
using CarShowroom.WebAPI.DTOs;

namespace CarShowroom.WebAPI.Infrastructure.Profiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarDTO>();
            CreateMap<CarDTO, Car>();
        }
    }
}
