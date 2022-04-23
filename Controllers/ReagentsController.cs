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
    public class ReagentsController : Controller
    {
        private readonly LabUserContext _context;

        public ReagentsController(LabUserContext context)
        {
            _context = context;
            //_context.Database.EnsureDeleted(); //added during model changes to ensure updates won't crash db
            _context.Database.EnsureCreated();
        }

        // GET: Reagents
        public async Task<IActionResult> Index()
        {
            var labUserContext = _context.Reagent.Include(r => r.Assay);
            return View(await labUserContext.ToListAsync());
        }

        // GET: Reagents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reagent = await _context.Reagent
                .Include(r => r.Assay)
                .FirstOrDefaultAsync(m => m.ReagentID == id);
            if (reagent == null)
            {
                return NotFound();
            }

            return View(reagent);
        }

        // GET: Reagents/Create
        public IActionResult Create()
        {
            ViewData["AssayID"] = new SelectList(_context.Assay, "AssayId", "AssayName");
            return View();
        }

        // POST: Reagents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReagentID,ReagentName,NumberOfVials,Location,UserID,AssayID")] Reagent reagent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reagent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssayID"] = new SelectList(_context.Assay, "AssayId", "AssayName", reagent.AssayID);
            return View(reagent);
        }

        // GET: Reagents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reagent = await _context.Reagent.FindAsync(id);
            if (reagent == null)
            {
                return NotFound();
            }
            ViewData["AssayID"] = new SelectList(_context.Assay, "AssayId", "AssayName", reagent.AssayID);
            return View(reagent);
        }

        // POST: Reagents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReagentID,ReagentName,NumberOfVials,Location,UserID,AssayID")] Reagent reagent)
        {
            if (id != reagent.ReagentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reagent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReagentExists(reagent.ReagentID))
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
            ViewData["AssayID"] = new SelectList(_context.Assay, "AssayId", "AssayName", reagent.AssayID);
            return View(reagent);
        }

        // GET: Reagents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reagent = await _context.Reagent
                .Include(r => r.Assay)
                .FirstOrDefaultAsync(m => m.ReagentID == id);
            if (reagent == null)
            {
                return NotFound();
            }

            return View(reagent);
        }

        // POST: Reagents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reagent = await _context.Reagent.FindAsync(id);
            _context.Reagent.Remove(reagent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReagentExists(int id)
        {
            return _context.Reagent.Any(e => e.ReagentID == id);
        }
    }
}
