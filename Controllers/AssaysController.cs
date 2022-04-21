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
    public class AssaysController : Controller
    {
        private readonly LabUserContext _context;

        private static Assay assay = new Assay();

        public AssaysController(LabUserContext context)
        {
            _context = context;
            //_context.Database.EnsureDeleted(); //added during model changes to ensure updates won't crash db
            _context.Database.EnsureCreated();
        }

        // GET: Assays
        public async Task<IActionResult> Index()
        {
            return View(await _context.Assay.ToListAsync());
        }

        // GET: Assays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assay = await _context.Assay
                .FirstOrDefaultAsync(m => m.AssayId == id);
            if (assay == null)
            {
                return NotFound();
            }

            return View(assay);
        }

        // GET: Assays/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Assays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssayId,AssayName,AssayDate,UserID")] Assay assay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assay);
        }

        // GET: Assays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assay = await _context.Assay.FindAsync(id);
            if (assay == null)
            {
                return NotFound();
            }
            return View(assay);
        }

        // POST: Assays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssayId,AssayName,AssayDate,UserID")] Assay assay)
        {
            if (id != assay.AssayId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssayExists(assay.AssayId))
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
            return View(assay);
        }

        // GET: Assays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assay = await _context.Assay
                .FirstOrDefaultAsync(m => m.AssayId == id);
            if (assay == null)
            {
                return NotFound();
            }

            return View(assay);
        }

        // POST: Assays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assay = await _context.Assay.FindAsync(id);
            _context.Assay.Remove(assay);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool AssayExists(int id)
        {
            return _context.Assay.Any(e => e.AssayId == id);
        }

        //ADDING REAGENTS TO CART
        public ActionResult AddReagent(int reagentID)
        {
            try
            {

            
                foreach (Reagent reagent in _context.Reagent)
                {
                    if (reagent.ReagentID == reagentID)
                    {
                        assay.AddReagent(reagent);
                        break;
                    }
                }
                return RedirectToAction("Index");


            }
            catch
            {
                return View();
            }

        }
    }

}
