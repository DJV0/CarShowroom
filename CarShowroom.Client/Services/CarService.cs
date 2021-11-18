using CarShowroom.Client.DTOs;
using CarShowroom.Client.Infrastructure.HttpClients;
using CarShowroom.Client.Infrastructure.HttpClients.Interfaces;
using CarShowroom.Client.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowroom.Client.Services
{
    public class CarService : ICarService
    {
        private readonly ICarClient _carClient;
        public CarService(ICarClient carClient)
        {
            _carClient = carClient;
        }

        public Task<CarDTO> GetCarById(int id)
        {
            return _carClient.GetById(id);
        }

        public async Task<IEnumerable<CarDTO>> GetCars()
        {
            return await _carClient.GetAll();
        }
    }
}
