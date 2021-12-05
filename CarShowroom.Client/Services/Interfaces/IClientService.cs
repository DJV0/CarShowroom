using CarShowroom.Client.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowroom.Client.Services.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDTO>> GetClients();
        Task<ClientDTO> GetClientById(int id);
        Task<bool> CreateClient(ClientDTO client);
        Task<bool> UpdateClient(int carId, ClientDTO client);
        Task<bool> DeleteClient(int id);
    }
}
