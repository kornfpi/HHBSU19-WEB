using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HabitatWebApp.Models
{
    public class Part
    {
        public int PartID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<PartSystemPart> PartSystemParts { get; } = new List<PartSystemPart>();
        // image
    }
}
