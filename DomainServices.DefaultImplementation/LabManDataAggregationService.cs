using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainServices.Interfaces;
using DomainModel.Interfaces;
using DomainModel;

namespace DomainServices.DefaultImplementation
{
    public class LabManDataAggregationService:ILabManDataAggregationService
    {
        private readonly IPersistenceContext persistenceContext = null;
        private readonly IStudentsRepository studentsRepository = null;
        private readonly IGroupsRepository groupsRepository = null;
        private readonly IGradesRepository gradesRepository = null;

        public LabManDataAggregationService(IPersistenceContext persistenceContext)
        {
            this.persistenceContext = persistenceContext;
            if (this.persistenceContext != null)
            {
                studentsRepository = this.persistenceContext.GetStudentsRepository();
                groupsRepository = this.persistenceContext.GetGroupsRepository();
            }
        }

        public float GetGradesAverageInGroup(Group studentGroup)
        {
            float retVal = 0;
            int studentsCount = 0;            
            ICollection<Student> students = studentsRepository.GetStudentsByGroupId(studentGroup.Id);

            foreach (Student student in students)
            {
                studentsCount++;
                retVal += GetStudentGradesAverage(student);
            }
            if (studentsCount > 0)
            {
                retVal = retVal / studentsCount;
            }
            return retVal;
        }

        public ICollection<Group> GetGroupsWithHighestAverage()
        {
            throw new NotImplementedException();
        }

        public ICollection<Student> GetStudentsWithHighestAverage()
        {
            throw new NotImplementedException();
        }

        public float GetStudentGradesAverage(Student student)
        {
            float retAvg = 0;
            int gradesCount = 0;
            ICollection<Grade> grades = gradesRepository.GetGradesForStudentWithId(student.Id);
            foreach (Grade grade in grades)
            {
                gradesCount++;
                retAvg += grade.Value;
            }
            if (gradesCount > 0)
            {
                retAvg = retAvg / gradesCount;
            }
            return retAvg;
        }
    }
}
