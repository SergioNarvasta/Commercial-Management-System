using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyBA.Data;
using PharmacyBA.Models;

namespace PharmacyBA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoteController : ControllerBase
    {
        private readonly PharmacyBAContext _context;

        public LoteController(PharmacyBAContext context)
        {
            _context = context;
        }

        // GET: api/Lote
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lote>>> GetLote()
        {
          if (_context.Lote == null)
          {
              return NotFound();
          }
            return await _context.Lote.ToListAsync();
        }

        // GET: api/Lote/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lote>> GetLote(int id)
        {
          if (_context.Lote == null)
          {
              return NotFound();
          }
            var lote = await _context.Lote.FindAsync(id);

            if (lote == null)
            {
                return NotFound();
            }

            return lote;
        }

        // PUT: api/Lote/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLote(int id, Lote lote)
        {
            if (id != lote.CodLote)
            {
                return BadRequest();
            }

            _context.Entry(lote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoteExists(id))
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

        // POST: api/Lote
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lote>> PostLote(Lote lote)
        {
          if (_context.Lote == null)
          {
              return Problem("Entity set 'PharmacyBAContext.Lote'  is null.");
          }
            _context.Lote.Add(lote);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLote", new { id = lote.CodLote }, lote);
        }

        // DELETE: api/Lote/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLote(int id)
        {
            if (_context.Lote == null)
            {
                return NotFound();
            }
            var lote = await _context.Lote.FindAsync(id);
            if (lote == null)
            {
                return NotFound();
            }

            _context.Lote.Remove(lote);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoteExists(int id)
        {
            return (_context.Lote?.Any(e => e.CodLote == id)).GetValueOrDefault();
        }
    }
}
