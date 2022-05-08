using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Chemical_Management.Data;
using Chemical_Management.Models;

namespace Chemical_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Reagents1Controller : ControllerBase
    {
        private readonly Chemical_ManagementContext _context;

        public Reagents1Controller(Chemical_ManagementContext context)
        {
            _context = context;
        }

        // GET: api/Reagents1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reagent>>> GetReagent()
        {
            return await _context.Reagent.ToListAsync();
        }

        // GET: api/Reagents1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reagent>> GetReagent(int id)
        {
            var reagent = await _context.Reagent.FindAsync(id);

            if (reagent == null)
            {
                return NotFound();
            }

            return reagent;
        }

        // PUT: api/Reagents1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReagent(int id, Reagent reagent)
        {
            if (id != reagent.ReagentID)
            {
                return BadRequest();
            }

            _context.Entry(reagent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReagentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Reagents1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reagent>> PostReagent(Reagent reagent)
        {
            _context.Reagent.Add(reagent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReagent", new { id = reagent.ReagentID }, reagent);
        }

        // DELETE: api/Reagents1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReagent(int id)
        {
            var reagent = await _context.Reagent.FindAsync(id);
            if (reagent == null)
            {
                return NotFound();
            }

            _context.Reagent.Remove(reagent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReagentExists(int id)
        {
            return _context.Reagent.Any(e => e.ReagentID == id);
        }
    }
}
