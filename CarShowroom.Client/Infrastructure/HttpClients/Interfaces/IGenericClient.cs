using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowroom.Client.Infrastructure.HttpClients.Interfaces
{
    public interface IGenericClient<T> where T: class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<bool> Create(T entity);
        Task<bool> Update(int entityId, T entity);
        Task<bool> Delete(int id);
    }
}
