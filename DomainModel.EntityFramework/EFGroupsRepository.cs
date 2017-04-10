using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel;
using DomainModel.Interfaces;

namespace DomainModel.EntityFramework
{
    public class EFGroupsRepository : EFGenericRepository<Group>, IGroupsRepository
    {
        public EFGroupsRepository(LabManDBContext dbContext) : base(dbContext)
        {
        }

        public Group GetByGroupName(string groupName)
        {
            return dbSet.FirstOrDefault(g => g.Name.CompareTo(groupName) == 0);
        }

        public ICollection<Group> GetGroupsForYear(int year)
        {
            return dbSet.Where(g => g.Year == year).ToList();
        }
    }
}
