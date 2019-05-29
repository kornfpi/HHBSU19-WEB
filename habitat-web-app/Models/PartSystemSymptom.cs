using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HabitatWebApp.Models
{
    public class PartSystemSymptom
    {
        public int PartSystemSymptomID { get; set; }

        public int PartSystemID { get; set; }
        public PartSystem PartSystem { get; set; }

        public int SymptomID { get; set; }
        public Symptom Symptom { get; set; }
    }
}
