using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel.Interfaces;
using DomainModel;
using Microsoft.EntityFrameworkCore;

namespace DomainModel.EntityFramework
{
    public class EFGenericRepository<T> : IGenericRepository<T> where T : UniqueObject
    {
        protected readonly LabManDBContext dbContext = null;
        protected readonly DbSet<T> dbSet = null;

        public EFGenericRepository(LabManDBContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<T>();

            this.dbContext.SaveChanges();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public T GetById(int id)
        {
            return dbSet.FirstOrDefault(entity => entity.Id == id);
            //throw new NotImplementedException();
        }

        public bool Remove(T entity)
        {
            return (dbSet.Remove(entity) != null);
            //throw new NotImplementedException();
        }

        public bool Update(T entity)
        {
            return (dbSet.Update(entity) != null);
        }
    }
}
