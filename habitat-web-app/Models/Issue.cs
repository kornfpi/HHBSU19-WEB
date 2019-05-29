using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HabitatWebApp.Models
{
    public enum Location
    {
        Kitchen, Utility, Living, Bathroom, Closet, Laundry, Hallway, Outside, Bedroom
    }

    // defines different categories of home issues, 'general' being an umbrella term
    // add electrician, emergency
    public enum Category
    {
        Plumbing, HVAC, Roofing, Structural, General
    }

    public class Issue
    {
       
        public int IssueID { get; set; }
        public string Title { get; set; }
        public Category? Category { get; set; }
        public Location? Location { get; set; }
        public ICollection<IssuePartSystem> IssuePartSystems { get; } = new List<IssuePartSystem>();
        public string Content { get; set; }
        public virtual ICollection<Image> Images { get; set; }



        // Vendors
    }
}
