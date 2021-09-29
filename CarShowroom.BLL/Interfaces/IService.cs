using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.BLL.Interfaces
{
    public interface IService<T>
    {
        void Add(T entity);
        T Get(int id);
        ICollection<T> GetAll();
        void Update(T entity);
        void Delete(int id);
    }
}
