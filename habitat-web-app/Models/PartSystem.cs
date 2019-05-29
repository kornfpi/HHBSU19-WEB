using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HabitatWebApp.Models
{
    public class PartSystem
    {
        public int PartSystemID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<IssuePartSystem> IssuePartSystems { get; } = new List<IssuePartSystem>();
        public ICollection<PartSystemPart> PartSystemParts { get; } = new List<PartSystemPart>();
        public ICollection<PartSystemSymptom> PartSystemSymptoms { get; } = new List<PartSystemSymptom>();
        
        // replacement parts
    }
}
