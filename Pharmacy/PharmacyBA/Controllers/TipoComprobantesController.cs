using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyBA.Data;
using PharmacyBA.Models;

namespace PharmacyBA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoComprobantesController : ControllerBase
    {
        private readonly PharmacyBAContext _context;

        public TipoComprobantesController(PharmacyBAContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoComprobante>>> GetTipoComprobante()
        {
          if (_context.TipoComprobante == null)
          {
              return NotFound();
          }
            return await _context.TipoComprobante.ToListAsync();
        }

        // GET: api/TipoComprobantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoComprobante>> GetTipoComprobante(int id)
        {
          if (_context.TipoComprobante == null)
          {
              return NotFound();
          }
            var tipoComprobante = await _context.TipoComprobante.FindAsync(id);

            if (tipoComprobante == null)
            {
                return NotFound();
            }

            return tipoComprobante;
        }

        // PUT: api/TipoComprobantes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoComprobante(int id, TipoComprobante tipoComprobante)
        {
            if (id != tipoComprobante.CodTipoComp)
            {
                return BadRequest();
            }

            _context.Entry(tipoComprobante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoComprobanteExists(id))
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

        // POST: api/TipoComprobantes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoComprobante>> PostTipoComprobante(TipoComprobante tipoComprobante)
        {
          if (_context.TipoComprobante == null)
          {
              return Problem("Entity set 'PharmacyBAContext.TipoComprobante'  is null.");
          }
            _context.TipoComprobante.Add(tipoComprobante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoComprobante", new { id = tipoComprobante.CodTipoComp }, tipoComprobante);
        }

        // DELETE: api/TipoComprobantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoComprobante(int id)
        {
            if (_context.TipoComprobante == null)
            {
                return NotFound();
            }
            var tipoComprobante = await _context.TipoComprobante.FindAsync(id);
            if (tipoComprobante == null)
            {
                return NotFound();
            }

            _context.TipoComprobante.Remove(tipoComprobante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoComprobanteExists(int id)
        {
            return (_context.TipoComprobante?.Any(e => e.CodTipoComp == id)).GetValueOrDefault();
        }
    }
}
