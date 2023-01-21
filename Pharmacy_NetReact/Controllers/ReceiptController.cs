
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using NETCore_React.Models;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptController : ControllerBase
    {
        private readonly APIDbContext _context;
        private readonly string _connection;
        public ReceiptController(APIDbContext context, IConfiguration configuration)
        {
            _context = context;
            _connection = configuration.GetConnectionString("DefaultConnection");
        }

        [HttpGet]
        [Route("Listado")]
        public async Task<ActionResult<IEnumerable<Receipt_RC>>> Listado()
        {

            var Lista = await _context.Receipt_RC.ToListAsync();
            return StatusCode(StatusCodes.Status200OK, Lista);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Receipt_RC>> GetRecibo(int id)
        {
            if (_context.Receipt_RC == null)
            {
                return NotFound();
            }
            var recibos = await _context.Receipt_RC.FindAsync(id);

            if (recibos == null)
            {
                return NotFound();
            }

            return recibos;
        }
        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] Receipt_RC recibo)
        {
            
            _context.Entry(recibo).State = EntityState.Modified;

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
        [Route("Registrar")]
        public async Task<ActionResult<Receipt_RC>> Registrar([FromBody] Receipt_RC recibo)
        {
            if (_context.Receipt_RC == null)
            {
                return Problem("Entity set Receipt_RC is null.");
            }
            _context.Receipt_RC.Add(recibo);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK,"Exito");
        }

        private bool ReciboExists(int id)
        {
            return (_context.Receipt_RC ? .Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
