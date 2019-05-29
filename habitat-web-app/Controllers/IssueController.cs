using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HabitatWebApp.Data;
using HabitatWebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace HabitatWebApp.Controllers
{
    //[Authorize(Roles = "Manager")]
    [Route("api/[controller]")]
    
    public class IssueController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IssueController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        // GET: Issue
        public  IActionResult Index()
        {
            return Json(_context.Issues);
        }
        
       
        

        

        

        

        

        
    }
}
