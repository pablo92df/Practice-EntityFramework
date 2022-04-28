using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCorePeliculas.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalasDeCine_Cines_CineId",
                table: "SalasDeCine");

            migrationBuilder.AddForeignKey(
                name: "FK_SalasDeCine_Cines_CineId",
                table: "SalasDeCine",
                column: "CineId",
                principalTable: "Cines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalasDeCine_Cines_CineId",
                table: "SalasDeCine");

            migrationBuilder.AddForeignKey(
                name: "FK_SalasDeCine_Cines_CineId",
                table: "SalasDeCine",
                column: "CineId",
                principalTable: "Cines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
