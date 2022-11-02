using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Data;
using Pharmacy.Models;

namespace Pharmacy.Controllers
{
    public class ProveedoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProveedoresController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
              return View(await _context.Proveedor.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Proveedor == null)
            {
                return NotFound();
            }
            var proveedor = await _context.Proveedor
                .FirstOrDefaultAsync(m => m.CodProveedor == id);
            if (proveedor == null)
            {
                return NotFound();
            }
            return View(proveedor);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodProveedor,Ruc,Codigo,Nombre,FechReg")] Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proveedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proveedor);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Proveedor == null)
            {
                return NotFound();
            }
            var proveedor = await _context.Proveedor.FindAsync(id);
            if (proveedor == null)
            {
                return NotFound();
            }
            return View(proveedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodProveedor,Ruc,Codigo,Nombre,FechReg")] Proveedor proveedor)
        {
            if (id != proveedor.CodProveedor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proveedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProveedorExists(proveedor.CodProveedor))
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
            return View(proveedor);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Proveedor == null)
            {
                return NotFound();
            }

            var proveedor = await _context.Proveedor
                .FirstOrDefaultAsync(m => m.CodProveedor == id);
            if (proveedor == null)
            {
                return NotFound();
            }

            return View(proveedor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Proveedor == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Proveedor'  is null.");
            }
            var proveedor = await _context.Proveedor.FindAsync(id);
            if (proveedor != null)
            {
                _context.Proveedor.Remove(proveedor);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool ProveedorExists(int id)
        {
          return _context.Proveedor.Any(e => e.CodProveedor == id);
        }
    }
}
