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
    public class DetalleVentaController : ControllerBase
    {
        private readonly PharmacyBAContext _context;
        public DetalleVentaController(PharmacyBAContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleVenta>>> GetDetalleVenta()
        {
          if (_context.DetalleVenta == null)
          {
              return NotFound();
          }
            return await _context.DetalleVenta.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleVenta>> GetDetalleVenta(int id)
        {
          if (_context.DetalleVenta == null)
          {
              return NotFound();
          }
            var detalleVenta = await _context.DetalleVenta.FindAsync(id);

            if (detalleVenta == null)
            {
                return NotFound();
            }

            return detalleVenta;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleVenta(int id, DetalleVenta detalleVenta)
        {
            if (id != detalleVenta.CodDetVenta)
            {
                return BadRequest();
            }

            _context.Entry(detalleVenta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleVentaExists(id))
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

        // POST: api/DetalleVentas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetalleVenta>> PostDetalleVenta(DetalleVenta detalleVenta)
        {
          if (_context.DetalleVenta == null)
          {
              return Problem("Entity set 'PharmacyBAContext.DetalleVenta'  is null.");
          }
            _context.DetalleVenta.Add(detalleVenta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleVenta", new { id = detalleVenta.CodDetVenta }, detalleVenta);
        }

        // DELETE: api/DetalleVentas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleVenta(int id)
        {
            if (_context.DetalleVenta == null)
            {
                return NotFound();
            }
            var detalleVenta = await _context.DetalleVenta.FindAsync(id);
            if (detalleVenta == null)
            {
                return NotFound();
            }

            _context.DetalleVenta.Remove(detalleVenta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleVentaExists(int id)
        {
            return (_context.DetalleVenta?.Any(e => e.CodDetVenta == id)).GetValueOrDefault();
        }
    }
}
