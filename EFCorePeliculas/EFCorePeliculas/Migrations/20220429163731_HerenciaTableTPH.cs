using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCorePeliculas.Migrations
{
    public partial class HerenciaTableTPH : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    FechaTransaccion = table.Column<DateTime>(type: "date", nullable: false),
                    TipoPago = table.Column<int>(type: "int", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Ultimos4Difitos = table.Column<string>(type: "char(4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Pagos",
                columns: new[] { "Id", "CorreoElectronico", "FechaTransaccion", "Price", "TipoPago" },
                values: new object[,]
                {
                    { 3, "pablito@gmail.com", new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 157m, 1 },
                    { 4, "pablito@gmail.com", new DateTime(2022, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 9.9m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Pagos",
                columns: new[] { "Id", "FechaTransaccion", "Price", "TipoPago", "Ultimos4Difitos" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 157m, 1, "1234" },
                    { 2, new DateTime(2022, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 91.9m, 1, "4321" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagos");
        }
    }
}
