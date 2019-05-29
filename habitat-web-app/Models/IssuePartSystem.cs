using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HabitatWebApp.Models
{
    // Join entity for many-to-many relationship
    public class IssuePartSystem
    {
        public int IssuePartSystemID { get; set; }

        public int IssueID { get; set; }
        public Issue Issue { get; set; }

        public int PartSystemID { get; set; }
        public PartSystem PartSystem { get; set; }
    }
}
