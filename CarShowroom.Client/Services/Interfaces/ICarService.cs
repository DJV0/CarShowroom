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
        Task<CarDetailsDTO> GetCarById(int id);
        Task<bool> CreateCar(CarDTO car);
    }
}
