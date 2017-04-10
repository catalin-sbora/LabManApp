using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DomainModel
{
    public class Group:UniqueObject
    {
        public String Name { get; set; }
        public Int32 Year { get; set; }
        [JsonIgnore]
        public virtual ICollection<Student> Students { get; set; }
    }
}
