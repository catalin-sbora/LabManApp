using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel.Interfaces;
using DomainModel;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace DomainModel.EntityFramework
{
    public class EFPersistenceContext:IPersistenceContext
    {
        private LabManDBContext dbContext = null;

        public EFPersistenceContext(IConfigurationRoot config)
        {
            InitializeContext(config);
        }

        public IGradesRepository GetGradesRepository()
        {
            return new EFGradesRepository(dbContext);
        }

        public IGroupsRepository GetGroupsRepository()
        {
            return new EFGroupsRepository(dbContext);
        }

        public IStudentsRepository GetStudentsRepository()
        {
            return new EFStudentsRepository(dbContext);
        }
        
        private void InitTablesWithData()
        {
            var dbGroups = dbContext.Set<Group>();
            List<Group> groupsList = new List<Group>
            {
                new Group { Name = "CR3H1A", Year = 3},
                new Group { Name = "CR3S1A", Year = 3}
            };
            dbGroups.AddRange(groupsList);
            
            var dbStudents = dbContext.Set<Student>();
            List<Student> studentsList = new List<Student>
            {
                new Student { FirstName = "Maria", LastName = "Popescu", Group = groupsList.ElementAt(0) },
                new Student { FirstName = "George", LastName = "Iacob", Group = groupsList.ElementAt(0)},
                new Student { FirstName = "Alexandru", LastName = "Ispas", Group = groupsList.ElementAt(1)},
                new Student { FirstName = "Nicolae", LastName = "Grigoras", Group = groupsList.ElementAt(1)},
                new Student { FirstName = "Robert", LastName = "Nita", Group = groupsList.ElementAt(1)}
            };
            dbStudents.AddRange(studentsList);
            var dbGrades = dbContext.Set<Grade>();
            List<Grade> gradesList = new List<Grade>
            {
                new Grade { Student = studentsList.ElementAt(0), Value=8},
                new Grade { Student = studentsList.ElementAt(0), Value=9},
                new Grade { Student = studentsList.ElementAt(0), Value=7},
                new Grade { Student = studentsList.ElementAt(1), Value=6},
                new Grade { Student = studentsList.ElementAt(1), Value=9},
                new Grade { Student = studentsList.ElementAt(1), Value=5},
                new Grade { Student = studentsList.ElementAt(2), Value=4},
                new Grade { Student = studentsList.ElementAt(2), Value=7},
                new Grade { Student = studentsList.ElementAt(2), Value=5},
                new Grade { Student = studentsList.ElementAt(3), Value=6},
                new Grade { Student = studentsList.ElementAt(3), Value=9},
                new Grade { Student = studentsList.ElementAt(3), Value=5},
                new Grade { Student = studentsList.ElementAt(4), Value=6},
                new Grade { Student = studentsList.ElementAt(4), Value=10},
                new Grade { Student = studentsList.ElementAt(4), Value=5}
            };
            dbGrades.AddRange(gradesList);

        }

        public bool InitializeContext(IConfigurationRoot configuration)
        {
            string connectionString = configuration.GetConnectionString("LabManDbContext");
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer(connectionString);
            dbContext = new LabManDBContext(optionsBuilder.Options);
            
            if (dbContext.Database.EnsureCreated())
            {
                InitTablesWithData();
                dbContext.SaveChanges();
            }
            return true;
        }

        public void ReleaseContext()
        {
            //throw new NotImplementedException();
        }

        public bool SaveAll()
        {
            if (dbContext != null)
            {
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
