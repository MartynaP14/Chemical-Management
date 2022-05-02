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
    public class TypesController : Controller
    {
        private readonly Chemical_ManagementContext _context;

        public TypesController(Chemical_ManagementContext context)
        {
            _context = context;
        }

        // GET: Types { Organic, Inorganic, Acid, Base, Corrosive, Toxic }
        public async Task<IActionResult> Index()
        {
            var AcidContext = _context.Type.Where(s => s.Reagent_Type == ReagentType.Acid).Count();
            var BaseContext = _context.Type.Where(s => s.Reagent_Type == ReagentType.Base).Count();
            var InorganicContext = _context.Type.Where(s => s.Reagent_Type == ReagentType.Inorganic).Count();
            var ToxicContext = _context.Type.Where(s => s.Reagent_Type == ReagentType.Toxic).Count();
            var OrganicContext = _context.Type.Where(s => s.Reagent_Type == ReagentType.Organic).Count();
            var CorrosiveContext = _context.Type.Where(s => s.Reagent_Type == ReagentType.Corrosive).Count();
            ViewBag.ACID = AcidContext;
            ViewBag.BASE = BaseContext;
            ViewBag.INORGANIC = InorganicContext;
            ViewBag.TOXIC = ToxicContext;
            ViewBag.ORGANIC = OrganicContext;
            ViewBag.CORROSIVE = CorrosiveContext;
            return View(await _context.Type.ToListAsync());
        }

        // GET: Types/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @type = await _context.Type
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@type == null)
            {
                return NotFound();
            }

            return View(@type);
        }

        // GET: Types/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Types/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Reagent_Type")] Models.Type @type)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@type);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@type);
        }

        // GET: Types/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @type = await _context.Type.FindAsync(id);
            if (@type == null)
            {
                return NotFound();
            }
            return View(@type);
        }

        // POST: Types/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Reagent_Type")] Models.Type @type)
        {
            if (id != @type.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@type);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeExists(@type.Id))
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
            return View(@type);
        }

        // GET: Types/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @type = await _context.Type
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@type == null)
            {
                return NotFound();
            }

            return View(@type);
        }

        // POST: Types/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @type = await _context.Type.FindAsync(id);
            _context.Type.Remove(@type);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeExists(int id)
        {
            return _context.Type.Any(e => e.Id == id);
        }
    }
}
