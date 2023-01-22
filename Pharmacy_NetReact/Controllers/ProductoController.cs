
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NETCore_React.Data;
using NETCore_React.Models;

namespace NETCore_React.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly APIDbContext _context;

        public ProductoController(APIDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("ListadoPrd")]
        public async Task<ActionResult<IEnumerable<Producto>>> ListadoProductos()
        {

            var Lista = await _context.Producto.ToListAsync();
            return StatusCode(StatusCodes.Status200OK, Lista);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> ObtenerProductoId(int id)
        {
            if (_context.Producto == null)
            {
                return NotFound();
            }
            var recibos = await _context.Producto.FindAsync(id);

            if (recibos == null)
            {
                return NotFound();
            }

            return recibos;
        }
        [HttpPut]
        [Route("EditarPrd")]
        public async Task<IActionResult> Editar([FromBody] Producto producto)
        {
            
            _context.Entry(producto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {                
                throw;  
            }

            return NoContent();
        }

        [HttpPost]
        [Route("RegistrarPrd")]
        public async Task<ActionResult<Producto>> Registrar([FromBody] Producto producto)
        {
            if (_context.Producto == null)
            {
                return Problem("Entity Producto is null.");
            }
            _context.Producto.Add(producto);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK,"Exito");
        }

        private bool ProductoExists(int id)
        {
            return (_context.Producto? .Any(e => e.IdProducto == id)).GetValueOrDefault();
        }
    }
}
