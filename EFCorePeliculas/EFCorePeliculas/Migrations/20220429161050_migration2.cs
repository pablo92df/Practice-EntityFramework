using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCorePeliculas.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodigoDeEtica",
                table: "Cines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Historia",
                table: "Cines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Misiones",
                table: "Cines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Valores",
                table: "Cines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "calle",
                table: "Cines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pais",
                table: "Cines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "provincia",
                table: "Cines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingAddress_calle",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingAddress_pais",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingAddress_provincia",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "calle",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pais",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "provincia",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CinesOfertas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaFin", "FechaInicio" },
                values: new object[] { new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 4, 29, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CinesOfertas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaFin", "FechaInicio" },
                values: new object[] { new DateTime(2022, 5, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 4, 29, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaEstreno",
                value: new DateTime(2022, 4, 29, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoDeEtica",
                table: "Cines");

            migrationBuilder.DropColumn(
                name: "Historia",
                table: "Cines");

            migrationBuilder.DropColumn(
                name: "Misiones",
                table: "Cines");

            migrationBuilder.DropColumn(
                name: "Valores",
                table: "Cines");

            migrationBuilder.DropColumn(
                name: "calle",
                table: "Cines");

            migrationBuilder.DropColumn(
                name: "pais",
                table: "Cines");

            migrationBuilder.DropColumn(
                name: "provincia",
                table: "Cines");

            migrationBuilder.DropColumn(
                name: "BillingAddress_calle",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "BillingAddress_pais",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "BillingAddress_provincia",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "calle",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "pais",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "provincia",
                table: "Actors");

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
        }
    }
}
