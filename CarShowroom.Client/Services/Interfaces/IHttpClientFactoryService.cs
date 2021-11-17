using CarShowroom.Client.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowroom.Client.Services.Interfaces
{
    public interface IHttpClientFactoryService
    {
        Task<IEnumerable<CarDTO>> GetCars();
    }
}
