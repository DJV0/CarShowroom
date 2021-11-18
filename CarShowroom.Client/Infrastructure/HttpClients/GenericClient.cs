using CarShowroom.Client.Infrastructure.HttpClients.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CarShowroom.Client.Infrastructure.HttpClients
{
    public abstract class GenericClient<T> : IGenericClient<T> where T: class
    {
        protected readonly HttpClient httpClient;
        protected readonly string requestString;
        public GenericClient(HttpClient client, string requestUri)
        {
            httpClient = client;
            requestString = requestUri;
        }

        public async Task<T> GetById(int id)
        {
            return await httpClient.GetFromJsonAsync<T>($"{requestString}/{id}");
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await httpClient.GetFromJsonAsync<List<T>>(requestString);
        }
    }
}
