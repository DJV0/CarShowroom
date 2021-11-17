using CarShowroom.Client.DTOs;
using CarShowroom.Client.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowroom.Client.Services
{
    public class CarService : ICarService
    {
        private readonly IHttpClientFactoryService _httpClientFactoryService;
        public CarService(IHttpClientFactoryService httpClientFactoryService)
        {
            _httpClientFactoryService = httpClientFactoryService;
        }

        public async Task<IEnumerable<CarDTO>> GetCars()
        {
            return await _httpClientFactoryService.GetCars();
        }
    }
}
