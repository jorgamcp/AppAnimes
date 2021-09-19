using Microsoft.EntityFrameworkCore.Migrations;

namespace AppAnimes.Migrations
{
    public partial class SetNullHistorial_Paginas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historial_Paginas_VistoEn",
                table: "Historial");

            migrationBuilder.AddForeignKey(
                name: "FK_Historial_Paginas_VistoEn",
                table: "Historial",
                column: "VistoEn",
                principalTable: "Paginas",
                principalColumn: "paginaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historial_Paginas_VistoEn",
                table: "Historial");

            migrationBuilder.AddForeignKey(
                name: "FK_Historial_Paginas_VistoEn",
                table: "Historial",
                column: "VistoEn",
                principalTable: "Paginas",
                principalColumn: "paginaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
