using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ReactVentas.Models;
using ReactVentas.Models.DTO;
using System.Data;
using System.Globalization;
using System.Xml.Linq;
namespace ReactVentas.Repositories
{
    public interface ICompraService 
    {

    }

    public class CompraService : ICompraService
    {
        private readonly DBREACT_VENTAContext _context;
        public CompraService(DBREACT_VENTAContext context)
        {
           _context = context;
        }
    
    /*
        public async Task<IActionResult> RegistraCompra (DtoCompra request){
            string numeroDocumento = "";
                XElement productos = new XElement("Productos");
                foreach (DtoProducto item in request.listaProductos)
                {
                    productos.Add(new XElement("Item",
                        new XElement("IdProducto", item.IdProducto),
                        new XElement("Cantidad", item.Cantidad),
                        new XElement("Precio", item.Precio),
                        new XElement("Total", item.Total)
                        ));
                }

                using (SqlConnection con = new SqlConnection(_context.Database.GetConnectionString()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_RegistrarVenta", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("documentoCliente", SqlDbType.VarChar, 40).Value = request.documentoCliente;
                    cmd.Parameters.Add("nombreCliente", SqlDbType.VarChar, 40).Value = request.nombreCliente;
                    cmd.Parameters.Add("tipoDocumento", SqlDbType.VarChar, 50).Value = request.tipoDocumento;
                    cmd.Parameters.Add("idUsuario", SqlDbType.Int).Value = request.idUsuario;
                    cmd.Parameters.Add("subTotal", SqlDbType.Decimal).Value = request.subTotal;
                    cmd.Parameters.Add("impuestoTotal", SqlDbType.Decimal).Value = request.igv;
                    cmd.Parameters.Add("total", SqlDbType.Decimal).Value = request.total;
                    cmd.Parameters.Add("productos", SqlDbType.Xml).Value = productos.ToString();
                    cmd.Parameters.Add("nroDocumento", SqlDbType.VarChar, 6).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    numeroDocumento = cmd.Parameters["nroDocumento"].Value.ToString();
                }

        }*/

    }
    

}
