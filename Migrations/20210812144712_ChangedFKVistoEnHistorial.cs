using Microsoft.EntityFrameworkCore.Migrations;

namespace AppAnimes.Migrations
{
    public partial class ChangedFKVistoEnHistorial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historial_Paginas_paginaId",
                table: "Historial");

            migrationBuilder.DropIndex(
                name: "IX_Historial_paginaId",
                table: "Historial");

            migrationBuilder.DropColumn(
                name: "paginaId",
                table: "Historial");

            migrationBuilder.CreateIndex(
                name: "IX_Historial_VistoEn",
                table: "Historial",
                column: "VistoEn");

            migrationBuilder.AddForeignKey(
                name: "FK_Historial_Paginas_VistoEn",
                table: "Historial",
                column: "VistoEn",
                principalTable: "Paginas",
                principalColumn: "paginaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historial_Paginas_VistoEn",
                table: "Historial");

            migrationBuilder.DropIndex(
                name: "IX_Historial_VistoEn",
                table: "Historial");

            migrationBuilder.AddColumn<int>(
                name: "paginaId",
                table: "Historial",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Historial_paginaId",
                table: "Historial",
                column: "paginaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Historial_Paginas_paginaId",
                table: "Historial",
                column: "paginaId",
                principalTable: "Paginas",
                principalColumn: "paginaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
