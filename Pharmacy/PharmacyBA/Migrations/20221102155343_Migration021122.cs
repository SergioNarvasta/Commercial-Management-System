using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmacyBA.Migrations
{
    public partial class Migration021122 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cantidad",
                table: "Producto",
                newName: "Stock");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Stock",
                table: "Producto",
                newName: "Cantidad");
        }
    }
}
