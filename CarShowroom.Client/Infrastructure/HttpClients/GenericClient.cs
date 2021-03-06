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

        public async Task<bool> Create(T entity)
        {
            var response = await httpClient.PostAsJsonAsync(requestString, entity);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Update(int entityId, T entity)
        {
            var response = await httpClient.PutAsJsonAsync($"{requestString}/{entityId}", entity);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await httpClient.DeleteAsync($"{requestString}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
