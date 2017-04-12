using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Grade:UniqueObject
    {   [JsonIgnore]     
        public Int32 StudentId { get; set; } 
        [JsonIgnore]
        public virtual Student Student { get; set; }               
        public float Value { get; set; }

    }
}
