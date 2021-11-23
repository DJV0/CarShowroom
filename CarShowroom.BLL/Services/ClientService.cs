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
    public class ClientService : Service<Client>, IClientService
    {
        public ClientService(CarShowroomDbContext context) : base(context) { }
        public override async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await context.Clients.Include(c => c.Cars).ToListAsync();
        }
        public override async Task<Client> GetByIdAsync(int id)
        {
            var client = await context.Clients
                .Include(c => c.Cars)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (client == null) throw new ItemNotFoundException($"{typeof(Client).Name} item with id {id} not found.");
            return client;
        }
    }
}
