using CarShowroom.Client.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowroom.Client.Services.Interfaces
{
    public interface IPartService
    {
        Task<IEnumerable<PartDTO>> GetParts();
        Task<PartDTO> GetPartById(int id);
        Task<bool> CreatePart(PartDTO part);
        Task<bool> UpdatePart(int partId, PartDTO part);
        Task<bool> DeletePart(int id);
    }
}
