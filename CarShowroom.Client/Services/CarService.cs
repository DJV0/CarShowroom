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

        public async Task<bool> CreateCar(CarDTO car)
        {
            return await _carClient.Create(car);
        }

        public async Task<bool> DeleteCar(int id)
        {
            return await _carClient.Delete(id);
        }

        public async Task<CarDTO> GetCarById(int id)
        {
            return await _carClient.GetById(id);
        }

        public async Task<IEnumerable<CarDTO>> GetCars()
        {
            return await _carClient.GetAll();
        }

        public async Task<bool> UpdateCar(int carId,CarDTO car)
        {
            return await _carClient.Update(carId, car);
        }
    }
}
