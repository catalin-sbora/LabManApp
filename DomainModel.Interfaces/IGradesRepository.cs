using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel.Interfaces
{
    public interface IGradesRepository:IGenericRepository<Grade>
    {
        ICollection<Grade> GetGradesForStudentWithId(Int32 studentId);
    }
}
