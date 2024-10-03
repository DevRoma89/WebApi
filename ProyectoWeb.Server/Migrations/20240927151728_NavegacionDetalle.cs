using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoWeb.Server.Migrations
{
    /// <inheritdoc />
    public partial class NavegacionDetalle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Detalles_LibroId",
                table: "Detalles",
                column: "LibroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Detalles_Libros_LibroId",
                table: "Detalles",
                column: "LibroId",
                principalTable: "Libros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Detalles_Libros_LibroId",
                table: "Detalles");

            migrationBuilder.DropIndex(
                name: "IX_Detalles_LibroId",
                table: "Detalles");
        }
    }
}
