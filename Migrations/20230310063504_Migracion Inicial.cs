using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Money_Tracker.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    categoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoriaNombre = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    categoriaIcono = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    categoriaTipo = table.Column<string>(type: "nvarchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.categoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Transacciones",
                columns: table => new
                {
                    transaccionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoriaID = table.Column<int>(type: "int", nullable: false),
                    transaccionMonto = table.Column<int>(type: "int", nullable: false),
                    transaccionDescripcion = table.Column<string>(type: "nvarchar(75)", nullable: true),
                    transaccionFecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacciones", x => x.transaccionId);
                    table.ForeignKey(
                        name: "FK_Transacciones_Categorias_categoriaID",
                        column: x => x.categoriaID,
                        principalTable: "Categorias",
                        principalColumn: "categoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_categoriaID",
                table: "Transacciones",
                column: "categoriaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transacciones");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
