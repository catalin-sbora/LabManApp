using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel;
namespace DomainServices.Interfaces
{
    public interface ILabManDataAggregationService
    {
        float GetGradesAverageInGroup(Group studentGroup);
        ICollection<Group> GetGroupsWithHighestAverage();
        ICollection<Student> GetStudentsWithHighestAverage();
    }
}
