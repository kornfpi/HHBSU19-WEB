using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HabitatWebApp.Models
{
    public class PartSystemPart
    {

        public int PartSystemPartID { get; set; }

        public int PartSystemID { get; set; }
        public PartSystem PartSystem { get; set; }

        public int PartID { get; set; }
        public Part Part { get; set; }
    }
}
