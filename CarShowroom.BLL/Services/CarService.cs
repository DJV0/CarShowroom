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
    public class CarService : Service<Car>, ICarService
    {
        private readonly IHttpClientServiceImplementation _client;
        public CarService(CarShowroomDbContext context, IHttpClientServiceImplementation client) : base(context)
        {
            _client = client;
        }

        public override async Task<Car> AddAsync(Car entity)
        {
            if(await context.Clients.FirstOrDefaultAsync(c => c.Id == entity.ClientId) == null) 
                throw new ItemNotFoundException($"{typeof(Client).Name} with id {entity.ClientId} not found");
            entity.ImageUrl = await _client.GetCarImageUrl($"{entity.Make} {entity.Model}");
            return await base.AddAsync(entity);
        }

    }
}
