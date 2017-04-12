using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel;
using DomainModel.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DomainModel.EntityFramework
{
    public class EFStudentsRepository : EFGenericRepository<Student>, IStudentsRepository
    {
        public EFStudentsRepository(LabManDBContext dbContext) : base(dbContext)
        {
            base.dependenciesToLoadList = new List<string> {"Group", "Grades"};
        }

        public ICollection<Student> GetStudentsByFirstName(string firstName)
        {
            
            return dbSet                
                .Include(s => s.Group)
                .Where(s => s.FirstName.CompareTo(firstName) == 0).ToList();
        }

        public ICollection<Student> GetStudentsByGroupId(int groupId)
        {
            return dbSet                
                .Include(s => s.Group)
                .Where(s => s.GroupId == groupId).ToList();
        }

        public ICollection<Student> GetStudentsByLastName(string lastName)
        {
            return dbSet
                .Include(s => s.Group)
                .Where(s => s.LastName.CompareTo(lastName) == 0).ToList();
        }
    }
}
