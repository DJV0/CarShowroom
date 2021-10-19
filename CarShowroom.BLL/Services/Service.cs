using Carshowroom.DAL;
using CarShowroom.BLL.Exceptions;
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
        public virtual T Add(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            T entity = Get(id);
            if(entity == null) throw new ItemNotFoundException($"{typeof(T).Name} with id {id} not found");
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }

        public virtual T Get(int id)
        {
            var entity = context.Set<T>().Find(id);
            if (entity == null) throw new ItemNotFoundException($"{typeof(T).Name} with id {id} not found");
            return entity;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public virtual void Update(T entity)
        {
            context.Set<T>().Update(entity);
            context.SaveChanges();
        }
    }
}
