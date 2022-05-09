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
    public class Labs1Controller : ControllerBase
    {
        private readonly Chemical_ManagementContext _context;

        public Labs1Controller(Chemical_ManagementContext context)
        {
            _context = context;
        }

        // GET: api/Labs1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lab>>> GetLab()
        {
            return await _context.Lab.ToListAsync();
        }

        // GET: api/Labs1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lab>> GetLab(int id)
        {
            var lab = await _context.Lab.FindAsync(id);

            if (lab == null)
            {
                return NotFound();
            }

            return lab;
        }

        // PUT: api/Labs1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLab(int id, Lab lab)
        {
            if (id != lab.LabID)
            {
                return BadRequest();
            }

            _context.Entry(lab).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LabExists(id))
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

        // POST: api/Labs1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lab>> PostLab(Lab lab)
        {
            _context.Lab.Add(lab);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLab", new { id = lab.LabID }, lab);
        }

        // DELETE: api/Labs1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLab(int id)
        {
            var lab = await _context.Lab.FindAsync(id);
            if (lab == null)
            {
                return NotFound();
            }

            _context.Lab.Remove(lab);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LabExists(int id)
        {
            return _context.Lab.Any(e => e.LabID == id);
        }
    }
}
