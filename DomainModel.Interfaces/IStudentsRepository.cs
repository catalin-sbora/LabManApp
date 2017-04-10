using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel.Interfaces
{
    public interface IStudentsRepository:IGenericRepository<Student>
    {
        ICollection<Student> GetStudentsByFirstName(String firstName);
        ICollection<Student> GetStudentsByLastName(String lastName);
        ICollection<Student> GetStudentsByGroupId(Int32 groupId);    
    }
}
