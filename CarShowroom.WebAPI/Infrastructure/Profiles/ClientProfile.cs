using AutoMapper;
using CarShowroom.Models.Entities;
using CarShowroom.WebAPI.DTOs;

namespace CarShowroom.WebAPI.Infrastructure.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, Client>();
            CreateMap<Client, ClientDTO>().ReverseMap();
        }
    }
}
