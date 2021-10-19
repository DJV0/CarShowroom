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
        public override Part Get(int id)
        {
            var part = context.Parts
                .Include(p=>p.OrderParts)
                .ThenInclude(op=>op.Order)
                .FirstOrDefault(p=>p.Id==id);
            if (part == null) throw new ItemNotFoundException($"{typeof(Part).Name} item with id {id} not found.");
            return part;
        }
    }
}
