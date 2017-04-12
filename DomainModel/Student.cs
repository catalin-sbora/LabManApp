using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Student:UniqueObject
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Int32 GroupId { get; set; }            
        public virtual Group Group { get; set; }
        [JsonIgnore]
        public virtual ICollection<Grade> Grades { get; set; } 
    }
}
