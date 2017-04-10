using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel.Interfaces
{
    public interface IGroupsRepository:IGenericRepository<Group>
    {
        Group GetByGroupName(String groupName);
        ICollection<Group> GetGroupsForYear(Int32 year);
    }
}
