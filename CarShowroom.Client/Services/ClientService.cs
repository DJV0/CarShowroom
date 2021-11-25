using CarShowroom.Client.DTOs;
using CarShowroom.Client.Infrastructure.HttpClients.Interfaces;
using CarShowroom.Client.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowroom.Client.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientClient _clientClient;
        public ClientService(IClientClient clientClient)
        {
            _clientClient = clientClient;
        }

        public async Task<bool> CreateClient(ClientDTO client)
        {
            return await _clientClient.Create(client);
        }

        public async Task<ClientDTO> GetClientById(int id)
        {
            return await _clientClient.GetById(id);
        }

        public async Task<IEnumerable<ClientDTO>> GetClients()
        {
            return await _clientClient.GetAll();
        }
    }
}
