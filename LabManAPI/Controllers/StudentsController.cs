using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DomainModel.Interfaces;
using DomainServices.Interfaces;
using DomainModel;
// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LabManAPI.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private readonly IPersistenceContext persistenceContext;
        private readonly ILabManDataAggregationService dataAggregationService;
        private readonly IStudentsRepository studentsRepository = null;        

        public StudentsController(IPersistenceContext context, ILabManDataAggregationService labManAgregationService)
        {
            persistenceContext = context;
            dataAggregationService = labManAgregationService;
            studentsRepository = persistenceContext.GetStudentsRepository();           
        }
        // GET: api/students
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            //gradesRepository.GetAll();
            
            return studentsRepository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {                        
            return studentsRepository.GetById(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Student value)
        {
            studentsRepository.Add(value);
            persistenceContext.SaveAll();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Student value)
        {
            studentsRepository.Update(value);
            persistenceContext.SaveAll();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            studentsRepository.Remove(new Student { Id = id });
            persistenceContext.SaveAll();
        }
    }
}
