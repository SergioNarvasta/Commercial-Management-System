using System.IO;
using System;
using System.IO.Compression;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactVentas.Models;
using System.Drawing;

namespace ReactVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchivoController : ControllerBase
    {
        private readonly DBREACT_VENTAContext _context;
        public ArchivoController(DBREACT_VENTAContext context)
        {
            _context = context;

        }

     /*   [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            List<Archivo> lista = new List<Archivo>();
            try
            {
                lista = await _context.Archivo.OrderByDescending(c => c.Archivo_Id).ToListAsync();

                return StatusCode(StatusCodes.Status200OK, lista);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, lista);
            }
        }
        
        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromForm] List<IFormFile> files)
        {
            List<Archivo> archivos = new List<Archivo>();
            try
            {
                if(files.Count > 0)
                {
                    foreach(var file in files)
                    {
                        var filePath = "C:\\Users\\snarv\\OneDrive\\Documentos\\2.PROYECTOS\\PharmacySoft_Ventas\\PharmacySoft\\ReactVentas\\Files\\"+file.FileName;
                        using(var stream = System.IO.File.Create(filePath))
                        {
                           await file.CopyToAsync(stream);
                        }
                        double tamanio = file.Length;
                        tamanio = tamanio / 1000000;
                        tamanio = Math.Round(tamanio, 2);
                        Archivo archivo = new Archivo();
                        archivo.Archivo_Extension = Path.GetExtension(file.FileName).Substring(1);
                        archivo.Archivo_Nombre = Path.GetFileNameWithoutExtension(file.FileName);
                        archivo.Archivo_Ubicacion = filePath;
                        archivo.Archivo_Tamanio = tamanio;
                        archivo.Archivo_Estado = 1;
                        using var ms = new System.IO.MemoryStream();
                        await file.CopyToAsync(ms);
                        Byte[] data = ms.ToArray();
                        String fileb64 = Convert.ToBase64String(data);

                        archivo.Archivo_Base64 = fileb64;
                        archivo.Aud_UsuCre = ""; //User Login
                        archivo.Aud_FecCre = DateTime.Now;
                        archivo.Aud_UsuAct = "";
                        archivo.Aud_FecAct = DateTime.Now;
                        archivos.Add(archivo);
                    }
                    _context.Archivo.AddRange(archivos);
                    _context.SaveChanges();
                }
                return StatusCode(StatusCodes.Status200OK, "ok");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }*/

    }
}
