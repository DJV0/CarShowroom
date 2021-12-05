using CarShowroom;
using CarShowroom.Client.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowroom.Client.Services.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<CarDTO>> GetCars();
        Task<CarDTO> GetCarById(int id);
        Task<bool> CreateCar(CarDTO car);
        Task<bool> UpdateCar(int carId, CarDTO car);
        Task<bool> DeleteCar(int id);
    }
}
