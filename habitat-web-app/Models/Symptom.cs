using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HabitatWebApp.Models
{
    public class Symptom
    {
        public int SymptomID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<PartSystemSymptom> PartSystemSymptoms { get; } = new List<PartSystemSymptom>();
    }
}
