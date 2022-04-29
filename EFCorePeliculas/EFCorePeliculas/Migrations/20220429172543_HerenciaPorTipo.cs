using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCorePeliculas.Migrations
{
    public partial class HerenciaPorTipo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Merchandising",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DisponibleEnInventario = table.Column<bool>(type: "bit", nullable: false),
                    Peso = table.Column<double>(type: "float", nullable: false),
                    Volumen = table.Column<double>(type: "float", nullable: false),
                    EsRopa = table.Column<bool>(type: "bit", nullable: false),
                    EsColeccionable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchandising", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Merchandising_Productos_Id",
                        column: x => x.Id,
                        principalTable: "Productos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PeliculaAlquilable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PeliculaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculaAlquilable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeliculaAlquilable_Productos_Id",
                        column: x => x.Id,
                        principalTable: "Productos",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Pagos",
                keyColumn: "Id",
                keyValue: 1,
                column: "TipoPago",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Pagos",
                keyColumn: "Id",
                keyValue: 2,
                column: "TipoPago",
                value: 2);

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 2, "Shirt One Piece", 11m },
                    { 1, "Spider-Man", 5.99m }
                });

            migrationBuilder.InsertData(
                table: "Merchandising",
                columns: new[] { "Id", "DisponibleEnInventario", "EsColeccionable", "EsRopa", "Peso", "Volumen" },
                values: new object[] { 2, true, false, true, 1.0, 1.0 });

            migrationBuilder.InsertData(
                table: "PeliculaAlquilable",
                columns: new[] { "Id", "PeliculaId" },
                values: new object[] { 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Merchandising");

            migrationBuilder.DropTable(
                name: "PeliculaAlquilable");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DeleteData(
                table: "Pagos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pagos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Pagos",
                columns: new[] { "Id", "FechaTransaccion", "Price", "TipoPago", "Ultimos4Difitos" },
                values: new object[] { 1, new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 157m, 1, "1234" });

            migrationBuilder.InsertData(
                table: "Pagos",
                columns: new[] { "Id", "FechaTransaccion", "Price", "TipoPago", "Ultimos4Difitos" },
                values: new object[] { 2, new DateTime(2022, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 91.9m, 1, "4321" });
        }
    }
}
