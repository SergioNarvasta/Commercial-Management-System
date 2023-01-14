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
    public class DetalleIngresoController : ControllerBase
    {
        private readonly PharmacyBAContext _context;
        public DetalleIngresoController(PharmacyBAContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleIngreso>>> GetDetalleIngreso()
        {
          if (_context.DetalleIngreso == null)
          {
              return NotFound();
          }
            return await _context.DetalleIngreso.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleIngreso>> GetDetalleIngreso(int id)
        {
          if (_context.DetalleIngreso == null)
          {
              return NotFound();
          }
            var detalleIngreso = await _context.DetalleIngreso.FindAsync(id);

            if (detalleIngreso == null)
            {
                return NotFound();
            }

            return detalleIngreso;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleIngreso(int id, DetalleIngreso detalleIngreso)
        {
            if (id != detalleIngreso.CodDetIng)
            {
                return BadRequest();
            }

            _context.Entry(detalleIngreso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleIngresoExists(id))
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

        // POST: api/DetalleIngresoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetalleIngreso>> PostDetalleIngreso(DetalleIngreso detalleIngreso)
        {
          if (_context.DetalleIngreso == null)
          {
              return Problem("Entity set 'PharmacyBAContext.DetalleIngreso'  is null.");
          }
            _context.DetalleIngreso.Add(detalleIngreso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleIngreso", new { id = detalleIngreso.CodDetIng }, detalleIngreso);
        }

        // DELETE: api/DetalleIngresoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleIngreso(int id)
        {
            if (_context.DetalleIngreso == null)
            {
                return NotFound();
            }
            var detalleIngreso = await _context.DetalleIngreso.FindAsync(id);
            if (detalleIngreso == null)
            {
                return NotFound();
            }

            _context.DetalleIngreso.Remove(detalleIngreso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleIngresoExists(int id)
        {
            return (_context.DetalleIngreso?.Any(e => e.CodDetIng == id)).GetValueOrDefault();
        }
    }
}
