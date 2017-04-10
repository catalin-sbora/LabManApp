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
        }

        public ICollection<Student> GetStudentsByFirstName(string firstName)
        {
            
            return dbSet
                .Include(s => s.Grades)
                .Where(s => s.FirstName.CompareTo(firstName) == 0).ToList();
        }

        public ICollection<Student> GetStudentsByGroupId(int groupId)
        {
            return dbSet
                .Include(s => s.Grades)
                .Where(s => s.GroupId == groupId).ToList();
        }

        public ICollection<Student> GetStudentsByLastName(string lastName)
        {
            return dbSet.Where(s => s.LastName.CompareTo(lastName) == 0).ToList();
        }
    }
}
