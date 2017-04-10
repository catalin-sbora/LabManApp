using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel;
using DomainModel.Interfaces;
namespace DomainModel.EntityFramework
{
    public class EFGradesRepository : EFGenericRepository<Grade>, IGradesRepository
    {
        public EFGradesRepository(LabManDBContext dbContext) : base(dbContext)
        {
        }
        public ICollection<Grade> GetGradesForStudentWithId(int studentId)
        {
           return dbSet.Where(g => g.StudentId == studentId).ToList();
        }
    }
}
