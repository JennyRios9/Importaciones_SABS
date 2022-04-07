using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Importaciones_SABS.Migrations
{
    public partial class Adiciondelastablaproductoycategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCategoria = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    NombreProducto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorUnitario = table.Column<double>(type: "float", nullable: false),
                    Iva = table.Column<double>(type: "float", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    FechaRegistro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Id_categoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
