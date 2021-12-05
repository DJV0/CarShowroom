using AutoMapper;
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
        private readonly IMapper _mapper;
        public ClientService(CarShowroomDbContext context, IMapper mapper) : base(context) => _mapper = mapper;
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
        public override async Task UpdateAsync(Client entity)
        {
            var dbClient = await GetByIdAsync(entity.Id);
            var carsToDelete = dbClient.Cars.Select(c=>c.Id).Except(entity.Cars.Select(c=>c.Id));
            var carsToAdd = entity.Cars.Select(c => c.Id).Except(dbClient.Cars.Select(c => c.Id));
            if (carsToDelete.Any())
            {
                foreach (var carId in carsToDelete)
                {
                    var carToDelete = dbClient.Cars.First(c => c.Id == carId);
                    dbClient.Cars.Remove(carToDelete);
                }
            }
            if (carsToAdd.Any())
            {
                foreach (var carId in carsToAdd)
                {
                    var carToAdd = entity.Cars.First(c => c.Id == carId);
                    dbClient.Cars.Add(carToAdd);
                }
            }
            context.Entry(dbClient).CurrentValues.SetValues(entity);
            await context.SaveChangesAsync();
        }
    }
}
