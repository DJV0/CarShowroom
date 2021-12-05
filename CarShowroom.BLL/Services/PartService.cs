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
    public class PartService : Service<Part>, IPartService
    {
        public PartService(CarShowroomDbContext context) : base(context) { }
    }
}
