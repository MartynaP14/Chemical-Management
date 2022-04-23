﻿using System;
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
    public class ReagentController : Controller
    {
        private readonly LabUserContext _context;

        public ReagentController(LabUserContext context)
        {
            _context = context;
        }

        // GET: Reagent
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reagent.ToListAsync());
        }

        // GET: Reagent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reagent = await _context.Reagent
                .FirstOrDefaultAsync(m => m.ReagentID == id);
            if (reagent == null)
            {
                return NotFound();
            }

            return View(reagent);
        }

        // GET: Reagent/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reagent/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReagentID,ReagentName,NumberOfVials,Location,AnalystID")] Reagent reagent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reagent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reagent);
        }

        // GET: Reagent/Edit/5
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
            return View(reagent);
        }

        // POST: Reagent/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReagentID,ReagentName,NumberOfVials,Location,AnalystID")] Reagent reagent)
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
            return View(reagent);
        }

        // GET: Reagent/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reagent = await _context.Reagent
                .FirstOrDefaultAsync(m => m.ReagentID == id);
            if (reagent == null)
            {
                return NotFound();
            }

            return View(reagent);
        }

        // POST: Reagent/Delete/5
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