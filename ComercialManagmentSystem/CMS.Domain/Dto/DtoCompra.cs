using System;
using System.ComponentModel.DataAnnotations;

namespace CMS.Domain.DTO
{
    public class DtoCompra
    {
        public int idProveedor { get; set; }

        public int idUsuario { get; set; }

        public decimal subTotal { get; set; }

        public decimal igv { get; set; }

        public decimal total { get; set; }

        public List<DtoProducto> listaProductos { get; set; }

    }
}
