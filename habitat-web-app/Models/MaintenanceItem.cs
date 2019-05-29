using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HabitatWebApp.Models
{
    public class MaintenanceItem
    {
        public int MaintenanceItemID { get; set; }
        public string Name { get; set; }
        // number of days in between reminders
        public int RecurrencePeriod { get; set; }
        // to link back to relevant Issue page
        public Issue Issue { get; set; }
    }
}
