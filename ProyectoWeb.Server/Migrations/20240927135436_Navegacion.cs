using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoWeb.Server.Migrations
{
    /// <inheritdoc />
    public partial class Navegacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Cabeceras_ClienteId",
                table: "Cabeceras",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Cabeceras_UsuarioId",
                table: "Cabeceras",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cabeceras_Clientes_ClienteId",
                table: "Cabeceras",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cabeceras_Usuarios_UsuarioId",
                table: "Cabeceras",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cabeceras_Clientes_ClienteId",
                table: "Cabeceras");

            migrationBuilder.DropForeignKey(
                name: "FK_Cabeceras_Usuarios_UsuarioId",
                table: "Cabeceras");

            migrationBuilder.DropIndex(
                name: "IX_Cabeceras_ClienteId",
                table: "Cabeceras");

            migrationBuilder.DropIndex(
                name: "IX_Cabeceras_UsuarioId",
                table: "Cabeceras");
        }
    }
}
