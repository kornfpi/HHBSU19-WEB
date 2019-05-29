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
    [Authorize(Roles = "Manager")]
    public class MaintenanceItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MaintenanceItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MaintenanceItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.MaintenanceItems.ToListAsync());
        }

        // GET: MaintenanceItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintenanceItem = await _context.MaintenanceItems
                .SingleOrDefaultAsync(m => m.MaintenanceItemID == id);
            if (maintenanceItem == null)
            {
                return NotFound();
            }

            return View(maintenanceItem);
        }

        // GET: MaintenanceItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MaintenanceItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaintenanceItemID,Name,RecurrencePeriod")] MaintenanceItem maintenanceItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maintenanceItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(maintenanceItem);
        }

        // GET: MaintenanceItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintenanceItem = await _context.MaintenanceItems.SingleOrDefaultAsync(m => m.MaintenanceItemID == id);
            if (maintenanceItem == null)
            {
                return NotFound();
            }
            return View(maintenanceItem);
        }

        // POST: MaintenanceItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaintenanceItemID,Name,RecurrencePeriod")] MaintenanceItem maintenanceItem)
        {
            if (id != maintenanceItem.MaintenanceItemID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maintenanceItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaintenanceItemExists(maintenanceItem.MaintenanceItemID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(maintenanceItem);
        }

        // GET: MaintenanceItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintenanceItem = await _context.MaintenanceItems
                .SingleOrDefaultAsync(m => m.MaintenanceItemID == id);
            if (maintenanceItem == null)
            {
                return NotFound();
            }

            return View(maintenanceItem);
        }

        // POST: MaintenanceItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var maintenanceItem = await _context.MaintenanceItems.SingleOrDefaultAsync(m => m.MaintenanceItemID == id);
            _context.MaintenanceItems.Remove(maintenanceItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaintenanceItemExists(int id)
        {
            return _context.MaintenanceItems.Any(e => e.MaintenanceItemID == id);
        }
    }
}
