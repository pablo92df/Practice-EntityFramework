using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCorePeliculas.Migrations
{
    public partial class InverseProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinesOfertas_Cines_CineId",
                table: "CinesOfertas");

            migrationBuilder.DropIndex(
                name: "IX_CinesOfertas_CineId",
                table: "CinesOfertas");

            migrationBuilder.AlterColumn<int>(
                name: "CineId",
                table: "CinesOfertas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mensajes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contenido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmisorID = table.Column<int>(type: "int", nullable: false),
                    ReceptorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensajes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mensajes_Personas_EmisorID",
                        column: x => x.EmisorID,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mensajes_Personas_ReceptorID",
                        column: x => x.ReceptorID,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "CinesOfertas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaFin", "FechaInicio" },
                values: new object[] { new DateTime(2022, 5, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 4, 28, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CinesOfertas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaFin", "FechaInicio" },
                values: new object[] { new DateTime(2022, 5, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 4, 28, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaEstreno",
                value: new DateTime(2022, 4, 28, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Felipe" },
                    { 2, "Claudia" }
                });

            migrationBuilder.InsertData(
                table: "Mensajes",
                columns: new[] { "Id", "Contenido", "EmisorID", "ReceptorID" },
                values: new object[,]
                {
                    { 1, "Hola, Claudia!", 1, 2 },
                    { 2, "Hola, Felipe, ¿Cómo te va?", 2, 1 },
                    { 3, "Todo bien, ¿Y tú?", 1, 2 },
                    { 4, "Muy bien :)", 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CinesOfertas_CineId",
                table: "CinesOfertas",
                column: "CineId",
                unique: true,
                filter: "[CineId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Mensajes_EmisorID",
                table: "Mensajes",
                column: "EmisorID");

            migrationBuilder.CreateIndex(
                name: "IX_Mensajes_ReceptorID",
                table: "Mensajes",
                column: "ReceptorID");

            migrationBuilder.AddForeignKey(
                name: "FK_CinesOfertas_Cines_CineId",
                table: "CinesOfertas",
                column: "CineId",
                principalTable: "Cines",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinesOfertas_Cines_CineId",
                table: "CinesOfertas");

            migrationBuilder.DropTable(
                name: "Mensajes");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_CinesOfertas_CineId",
                table: "CinesOfertas");

            migrationBuilder.AlterColumn<int>(
                name: "CineId",
                table: "CinesOfertas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "CinesOfertas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaFin", "FechaInicio" },
                values: new object[] { new DateTime(2022, 5, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 4, 26, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CinesOfertas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaFin", "FechaInicio" },
                values: new object[] { new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 4, 26, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaEstreno",
                value: new DateTime(2022, 4, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_CinesOfertas_CineId",
                table: "CinesOfertas",
                column: "CineId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CinesOfertas_Cines_CineId",
                table: "CinesOfertas",
                column: "CineId",
                principalTable: "Cines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
