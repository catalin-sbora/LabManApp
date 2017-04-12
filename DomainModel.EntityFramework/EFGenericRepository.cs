using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel.Interfaces;
using DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace DomainModel.EntityFramework
{
    public class EFGenericRepository<T> : IGenericRepository<T> where T : UniqueObject
    {
        protected readonly LabManDBContext dbContext = null;
        protected readonly DbSet<T> dbSet = null;
        protected List<String> dependenciesToLoadList = null; 

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
            IQueryable<T> result = dbSet;
            if (dependenciesToLoadList != null)
            {
                foreach (String dependency in dependenciesToLoadList)
                {
                    result = result.Include(dependency);
                }
            }                  
            return result.ToList();
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
