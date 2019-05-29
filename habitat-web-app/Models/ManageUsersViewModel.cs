using System.Collections.Generic;
using HabitatWebApp.Models;
namespace HabitatWebApp.Models
{
    public class ManageUsersViewModel
    {
        public ApplicationUser[] Administrators { get; set; }
        public ApplicationUser[] Employees { get; set; }
        public ApplicationUser[] Everyone { get; set; }
    }
}