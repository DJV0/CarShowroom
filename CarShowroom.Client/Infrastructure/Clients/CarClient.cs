using CarShowroom.Client.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CarShowroom.Client.Infrastructure.Clients
{
    public class CarClient
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;
        public CarClient(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("https://localhost:44362/api/");
            _client.Timeout = new TimeSpan(0, 0, 30);
            _client.DefaultRequestHeaders.Clear();

            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<IEnumerable<CarDTO>> GetCars()
        {
            using (var response = await _client.GetAsync("car", HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();
                var stream = await response.Content.ReadAsStreamAsync();
                var cars = await JsonSerializer.DeserializeAsync<IEnumerable<CarDTO>>(stream, _options);
                return cars;
            }
        }
    }
}
