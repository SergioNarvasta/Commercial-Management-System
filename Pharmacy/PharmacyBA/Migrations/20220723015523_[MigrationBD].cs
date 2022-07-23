using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmacyBA.Migrations
{
    public partial class MigrationBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    CodCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    DNI = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    RUC = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    RazonSocial = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaReg = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.CodCliente);
                });

            migrationBuilder.CreateTable(
                name: "Lote",
                columns: table => new
                {
                    CodLote = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaVen = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegSanit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lote", x => x.CodLote);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    CodProveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ruc = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechReg = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.CodProveedor);
                });

            migrationBuilder.CreateTable(
                name: "TipoComprobante",
                columns: table => new
                {
                    CodTipoComp = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoComprobante", x => x.CodTipoComp);
                });

            migrationBuilder.CreateTable(
                name: "TipoUsuario",
                columns: table => new
                {
                    CodTipoUsu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuario", x => x.CodTipoUsu);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    CodProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Correlativo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    NombreCientifico = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Concentracion = table.Column<decimal>(type: "decimal(18,2)", maxLength: 10, nullable: false),
                    Presentacion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PrecioVenta = table.Column<decimal>(type: "decimal(18,2)", maxLength: 10, nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(18,2)", maxLength: 10, nullable: false),
                    Restriccion = table.Column<bool>(type: "bit", maxLength: 5, nullable: false),
                    CodLote = table.Column<int>(type: "int", nullable: false),
                    LoteCodLote = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.CodProducto);
                    table.ForeignKey(
                        name: "FK_Producto_Lote_LoteCodLote",
                        column: x => x.LoteCodLote,
                        principalTable: "Lote",
                        principalColumn: "CodLote",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    CodUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apellidos = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    User = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DNI = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaReg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdTipoUsuario = table.Column<int>(type: "int", nullable: false),
                    TipoUsuarioCodTipoUsu = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.CodUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_TipoUsuario_TipoUsuarioCodTipoUsu",
                        column: x => x.TipoUsuarioCodTipoUsu,
                        principalTable: "TipoUsuario",
                        principalColumn: "CodTipoUsu");
                });

            migrationBuilder.CreateTable(
                name: "Ingreso",
                columns: table => new
                {
                    CodIngreso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FecIng = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Totalcompra = table.Column<double>(type: "float", nullable: false),
                    CodUsuario = table.Column<int>(type: "int", nullable: false),
                    UsuarioCodUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingreso", x => x.CodIngreso);
                    table.ForeignKey(
                        name: "FK_Ingreso_Usuario_UsuarioCodUsuario",
                        column: x => x.UsuarioCodUsuario,
                        principalTable: "Usuario",
                        principalColumn: "CodUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    Codventa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descuento = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoPago = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodTipoComp = table.Column<int>(type: "int", nullable: false),
                    TipoComprobanteCodTipoComp = table.Column<int>(type: "int", nullable: false),
                    CodUsuario = table.Column<int>(type: "int", nullable: false),
                    UsuarioCodUsuario = table.Column<int>(type: "int", nullable: false),
                    CodCliente = table.Column<int>(type: "int", nullable: false),
                    ClienteCodCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta", x => x.Codventa);
                    table.ForeignKey(
                        name: "FK_Venta_Cliente_ClienteCodCliente",
                        column: x => x.ClienteCodCliente,
                        principalTable: "Cliente",
                        principalColumn: "CodCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venta_TipoComprobante_TipoComprobanteCodTipoComp",
                        column: x => x.TipoComprobanteCodTipoComp,
                        principalTable: "TipoComprobante",
                        principalColumn: "CodTipoComp",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venta_Usuario_UsuarioCodUsuario",
                        column: x => x.UsuarioCodUsuario,
                        principalTable: "Usuario",
                        principalColumn: "CodUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleIngreso",
                columns: table => new
                {
                    CodDetIng = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    UniMedida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    SubTotal = table.Column<double>(type: "float", nullable: false),
                    CodIngreso = table.Column<int>(type: "int", nullable: false),
                    IngresoCodIngreso = table.Column<int>(type: "int", nullable: true),
                    CodProducto = table.Column<int>(type: "int", nullable: false),
                    ProductoCodProducto = table.Column<int>(type: "int", nullable: true),
                    CodProveedor = table.Column<int>(type: "int", nullable: false),
                    ProveedorCodProveedor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleIngreso", x => x.CodDetIng);
                    table.ForeignKey(
                        name: "FK_DetalleIngreso_Ingreso_IngresoCodIngreso",
                        column: x => x.IngresoCodIngreso,
                        principalTable: "Ingreso",
                        principalColumn: "CodIngreso");
                    table.ForeignKey(
                        name: "FK_DetalleIngreso_Producto_ProductoCodProducto",
                        column: x => x.ProductoCodProducto,
                        principalTable: "Producto",
                        principalColumn: "CodProducto");
                    table.ForeignKey(
                        name: "FK_DetalleIngreso_Proveedor_ProveedorCodProveedor",
                        column: x => x.ProveedorCodProveedor,
                        principalTable: "Proveedor",
                        principalColumn: "CodProveedor");
                });

            migrationBuilder.CreateTable(
                name: "DetalleVenta",
                columns: table => new
                {
                    CodDetVenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Subtotal = table.Column<double>(type: "float", nullable: false),
                    IGV = table.Column<double>(type: "float", nullable: false),
                    CodProducto = table.Column<int>(type: "int", nullable: false),
                    ProductoCodProducto = table.Column<int>(type: "int", nullable: false),
                    CodVenta = table.Column<int>(type: "int", nullable: false),
                    VentaCodventa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleVenta", x => x.CodDetVenta);
                    table.ForeignKey(
                        name: "FK_DetalleVenta_Producto_ProductoCodProducto",
                        column: x => x.ProductoCodProducto,
                        principalTable: "Producto",
                        principalColumn: "CodProducto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleVenta_Venta_VentaCodventa",
                        column: x => x.VentaCodventa,
                        principalTable: "Venta",
                        principalColumn: "Codventa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleIngreso_IngresoCodIngreso",
                table: "DetalleIngreso",
                column: "IngresoCodIngreso");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleIngreso_ProductoCodProducto",
                table: "DetalleIngreso",
                column: "ProductoCodProducto");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleIngreso_ProveedorCodProveedor",
                table: "DetalleIngreso",
                column: "ProveedorCodProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVenta_ProductoCodProducto",
                table: "DetalleVenta",
                column: "ProductoCodProducto");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVenta_VentaCodventa",
                table: "DetalleVenta",
                column: "VentaCodventa");

            migrationBuilder.CreateIndex(
                name: "IX_Ingreso_UsuarioCodUsuario",
                table: "Ingreso",
                column: "UsuarioCodUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_LoteCodLote",
                table: "Producto",
                column: "LoteCodLote");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_TipoUsuarioCodTipoUsu",
                table: "Usuario",
                column: "TipoUsuarioCodTipoUsu");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_ClienteCodCliente",
                table: "Venta",
                column: "ClienteCodCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_TipoComprobanteCodTipoComp",
                table: "Venta",
                column: "TipoComprobanteCodTipoComp");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_UsuarioCodUsuario",
                table: "Venta",
                column: "UsuarioCodUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleIngreso");

            migrationBuilder.DropTable(
                name: "DetalleVenta");

            migrationBuilder.DropTable(
                name: "Ingreso");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Venta");

            migrationBuilder.DropTable(
                name: "Lote");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "TipoComprobante");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "TipoUsuario");
        }
    }
}
