using Carshowroom.DAL;
using CarShowroom.BLL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.BLL.Services
{
    public class Service<T> : IService<T> where T: class
    {
        protected readonly CarShowroomDbContext context;

        public Service(CarShowroomDbContext context)
        {
            this.context = context;
        }
        public T Add(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            T entity = Get(id);
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }

        public T Get(int id)
        {
            return context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
            context.SaveChanges();
        }
    }
}
