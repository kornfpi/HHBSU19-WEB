using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HabitatWebApp.Data;
using HabitatWebApp.Models;

namespace HabitatWebApp.Controllers
{
    public class PartSystemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PartSystemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PartSystems
        public async Task<IActionResult> Index()
        {
            return View(await _context.PartSystems.ToListAsync());
        }

        // GET: PartSystems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partSystem = await _context.PartSystems
                .SingleOrDefaultAsync(m => m.PartSystemID == id);
            if (partSystem == null)
            {
                return NotFound();
            }

            return View(partSystem);
        }

        // GET: PartSystems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PartSystems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PartSystemID,Name,Description")] PartSystem partSystem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partSystem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(partSystem);
        }

        // GET: PartSystems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partSystem = await _context.PartSystems.SingleOrDefaultAsync(m => m.PartSystemID == id);
            if (partSystem == null)
            {
                return NotFound();
            }
            return View(partSystem);
        }

        // POST: PartSystems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PartSystemID,Name,Description")] PartSystem partSystem)
        {
            if (id != partSystem.PartSystemID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partSystem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartSystemExists(partSystem.PartSystemID))
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
            return View(partSystem);
        }

        // GET: PartSystems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partSystem = await _context.PartSystems
                .SingleOrDefaultAsync(m => m.PartSystemID == id);
            if (partSystem == null)
            {
                return NotFound();
            }

            return View(partSystem);
        }

        // POST: PartSystems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partSystem = await _context.PartSystems.SingleOrDefaultAsync(m => m.PartSystemID == id);
            _context.PartSystems.Remove(partSystem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartSystemExists(int id)
        {
            return _context.PartSystems.Any(e => e.PartSystemID == id);
        }
    }
}
