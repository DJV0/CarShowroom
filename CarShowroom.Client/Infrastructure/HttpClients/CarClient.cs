using CarShowroom.Client.DTOs;
using CarShowroom.Client.Infrastructure.HttpClients.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CarShowroom.Client.Infrastructure.HttpClients
{
    public class CarClient : GenericClient<CarDTO>, ICarClient
    {
        public CarClient(HttpClient client) : base(client, "car") { }

        public new async Task<CarDetailsDTO> GetById(int id)
        {
            return await httpClient.GetFromJsonAsync<CarDetailsDTO>($"{requestString}/{id}");
        }
    }
}
