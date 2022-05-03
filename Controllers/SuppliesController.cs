using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Chemical_Management.Data;
using Chemical_Management.Models;

namespace Chemical_Management.Controllers
{
    public class SuppliesController : Controller
    {
        private readonly Chemical_ManagementContext _context;

        public SuppliesController(Chemical_ManagementContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        // GET: Supplies
        public async Task<IActionResult> Index()
        {
            var chemical_ManagementContext = _context.Supply.Include(s => s.Lab).Include(s => s.Reagent);
            return View(await chemical_ManagementContext.ToListAsync());
        }

        // GET: Supplies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supply = await _context.Supply
                .Include(s => s.Lab)
                .Include(s => s.Reagent)
                .FirstOrDefaultAsync(m => m.SupplyId == id);
            if (supply == null)
            {
                return NotFound();
            }

            return View(supply);
        }

        // GET: Supplies/Create
        public IActionResult Create()
        {
            ViewData["LabID"] = new SelectList(_context.Lab, "LabID", "LabName");
            ViewData["ReagentId"] = new SelectList(_context.Reagent, "ReagentID", "ReagentName");
            return View();
        }

        // POST: Supplies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplyId,ReagentId,LabID,ReagentStock")] Supply supply)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supply);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LabID"] = new SelectList(_context.Lab, "LabID", "LabName", supply.LabID);
            ViewData["ReagentId"] = new SelectList(_context.Reagent, "ReagentID", "ReagentName", supply.ReagentId);
            return View(supply);
        }

        // GET: Supplies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supply = await _context.Supply.FindAsync(id);
            if (supply == null)
            {
                return NotFound();
            }
            ViewData["LabID"] = new SelectList(_context.Lab, "LabID", "LabName", supply.LabID);
            ViewData["ReagentId"] = new SelectList(_context.Reagent, "ReagentID", "ReagentName", supply.ReagentId);
            return View(supply);
        }

        // POST: Supplies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupplyId,ReagentId,LabID,ReagentStock")] Supply supply)
        {
            if (id != supply.SupplyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supply);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplyExists(supply.SupplyId))
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
            ViewData["LabID"] = new SelectList(_context.Lab, "LabID", "LabName", supply.LabID);
            ViewData["ReagentId"] = new SelectList(_context.Reagent, "ReagentID", "ReagentName", supply.ReagentId);
            return View(supply);
        }

        // GET: Supplies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supply = await _context.Supply
                .Include(s => s.Lab)
                .Include(s => s.Reagent)
                .FirstOrDefaultAsync(m => m.SupplyId == id);
            if (supply == null)
            {
                return NotFound();
            }

            return View(supply);
        }

        // POST: Supplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supply = await _context.Supply.FindAsync(id);
            _context.Supply.Remove(supply);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupplyExists(int id)
        {
            return _context.Supply.Any(e => e.SupplyId == id);
        }
    }
}
