using CarShowroom.Client.DTOs;
using CarShowroom.Client.Infrastructure.HttpClients.Interfaces;
using CarShowroom.Client.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowroom.Client.Services
{
    public class PartService : IPartService
    {
        private readonly IPartClient _partClient;
        public PartService(IPartClient partClient)
        {
            _partClient = partClient;
        }
        public async Task<bool> CreatePart(PartDTO part)
        {
            return await _partClient.Create(part);
        }

        public async Task<bool> DeletePart(int id)
        {
            return await _partClient.Delete(id);
        }

        public async Task<PartDTO> GetPartById(int id)
        {
            return await _partClient.GetById(id);
        }

        public async Task<IEnumerable<PartDTO>> GetParts()
        {
            return await _partClient.GetAll();
        }

        public async Task<bool> UpdatePart(int partId, PartDTO part)
        {
            return await _partClient.Update(partId, part);
        }
    }
}
