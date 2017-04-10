using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel;

namespace DomainModel.Interfaces
{
    public interface IGenericRepository<T> where T: UniqueObject
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        bool Remove(T entity);
        bool Update(T entity);
    }
}
