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
    public class LabAnalystController : Controller
    {
        private readonly LabUserContext _context;

        public LabAnalystController(LabUserContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        // GET: LabAnalyst
        public async Task<IActionResult> Index()
        {
            return View(await _context.LabAnalyst.ToListAsync());
        }

        // GET: LabAnalyst/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labAnalyst = await _context.LabAnalyst
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (labAnalyst == null)
            {
                return NotFound();
            }

            return View(labAnalyst);
        }

        // GET: LabAnalyst/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LabAnalyst/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,Name,Permissions")] LabAnalyst labAnalyst)
        {
            if (ModelState.IsValid)
            {
                _context.Add(labAnalyst);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(labAnalyst);
        }

        // GET: LabAnalyst/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labAnalyst = await _context.LabAnalyst.FindAsync(id);
            if (labAnalyst == null)
            {
                return NotFound();
            }
            return View(labAnalyst);
        }

        // POST: LabAnalyst/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserID,Name,Permissions")] LabAnalyst labAnalyst)
        {
            if (id != labAnalyst.UserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(labAnalyst);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LabAnalystExists(labAnalyst.UserID))
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
            return View(labAnalyst);
        }

        // GET: LabAnalyst/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labAnalyst = await _context.LabAnalyst
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (labAnalyst == null)
            {
                return NotFound();
            }

            return View(labAnalyst);
        }

        // POST: LabAnalyst/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var labAnalyst = await _context.LabAnalyst.FindAsync(id);
            _context.LabAnalyst.Remove(labAnalyst);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LabAnalystExists(string id)
        {
            return _context.LabAnalyst.Any(e => e.UserID == id);
        }
    }
}