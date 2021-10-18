using Carshowroom.DAL;
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
    public class ClientService : Service<Client>, IClientService
    {
        public ClientService(CarShowroomDbContext context) : base(context) { }

        public override Client Get(int id)
        {
            return context.Clients
                .Include(c => c.Cars)
                .FirstOrDefault(c => c.Id == id);
        }
    }
}
