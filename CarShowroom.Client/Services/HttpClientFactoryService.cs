using CarShowroom.Client.DTOs;
using CarShowroom.Client.Infrastructure.Clients;
using CarShowroom.Client.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CarShowroom.Client.Services
{
    public class HttpClientFactoryService : IHttpClientFactoryService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly CarClient _carsClient;
        public HttpClientFactoryService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _carsClient = new CarClient(_httpClientFactory.CreateClient());
        }

        public async Task<IEnumerable<CarDTO>> GetCars() => await _carsClient.GetCars();
    }
}
