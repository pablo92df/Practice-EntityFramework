using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCorePeliculas.Migrations
{
    public partial class indiceNombre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TablaGeneros_Nombre",
                schema: "Peliculas",
                table: "TablaGeneros",
                column: "Nombre",
                unique: true,
                filter: "EstaBorrado = 'false'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TablaGeneros_Nombre",
                schema: "Peliculas",
                table: "TablaGeneros");
        }
    }
}
