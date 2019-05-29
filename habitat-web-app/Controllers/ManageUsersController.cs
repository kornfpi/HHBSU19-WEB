using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using HabitatWebApp.Models;
using Microsoft.EntityFrameworkCore;
using HabitatWebApp.Data;
using Microsoft.Extensions.DependencyInjection;

namespace HabitatWebApp.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ManageUsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser>
        _userManager;
        public ManageUsersController(
        UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            //Super admin
            var admins = (await _userManager
            .GetUsersInRoleAsync("Administrator"))
            .ToArray();
            //all users
            var everyone = await _userManager.Users
.ToArrayAsync();
            //all emplooyees
            var employees = (await _userManager
             .GetUsersInRoleAsync("Manager"))
             .ToArray();
            var model = new ManageUsersViewModel
            {
                Administrators = admins,
                Employees = employees,
                Everyone = everyone
            };
            return View(model);
        }


    }
}