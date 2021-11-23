using AutoMapper;
using CarShowroom.Models.Entities;
using CarShowroom.WebAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowroom.WebAPI.Infrastructure.Profiles
{
    public class PartProfile : Profile
    {
        public PartProfile()
        {
            CreateMap<Part, PartDTO>();
            CreateMap<PartDTO, Part>();
        }
    }
}
