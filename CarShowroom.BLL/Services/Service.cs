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
    public abstract class Service<T> : IService<T> where T: class
    {
        protected readonly CarShowroomDbContext context;

        public Service(CarShowroomDbContext context)
        {
            this.context = context;
        }
        public virtual async Task<T> AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            T entity = await GetByIdAsync(id);
            if(entity == null) throw new ItemNotFoundException($"{typeof(T).Name} with id {id} not found");
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            if (entity == null) throw new ItemNotFoundException($"{typeof(T).Name} with id {id} not found");
            return entity;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
