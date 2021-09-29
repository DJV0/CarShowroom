using Carshowroom.DAL;
using CarShowroom.BLL.Interfaces;
using CarShowroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.BLL.Services
{
    public class ClientService : IClientService
    {
        private readonly CarShowroomDbContext _context;
        public ClientService(CarShowroomDbContext context)
        {
            _context = context;
        }

        public void Add(Client entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Client Get(int id)
        {
            return _context.Clients.FirstOrDefault(client => client.Id == id);
        }

        public ICollection<Client> GetAll()
        {
            return _context.Clients.ToList();
        }

        public void Update(Client entity)
        {
            throw new NotImplementedException();
        }
    }
}
