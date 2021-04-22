using Microsoft.EntityFrameworkCore.Migrations;

namespace AppAnimes.Migrations
{
    public partial class UnionHistorialTemporadas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdTemporadaNavigationIdAnime",
                table: "Temporadas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdTemporadaNavigationIdTemporada",
                table: "Temporadas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdTemporadaNavigationIdAnime",
                table: "Historial",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdTemporadaNavigationIdTemporada",
                table: "Historial",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Temporadas_IdTemporadaNavigationIdAnime_IdTemporadaNavigationIdTemporada",
                table: "Temporadas",
                columns: new[] { "IdTemporadaNavigationIdAnime", "IdTemporadaNavigationIdTemporada" });

            migrationBuilder.CreateIndex(
                name: "IX_Historial_IdTemporadaNavigationIdAnime_IdTemporadaNavigationIdTemporada",
                table: "Historial",
                columns: new[] { "IdTemporadaNavigationIdAnime", "IdTemporadaNavigationIdTemporada" });

            migrationBuilder.AddForeignKey(
                name: "FK_Historial_Temporadas_IdTemporadaNavigationIdAnime_IdTemporadaNavigationIdTemporada",
                table: "Historial",
                columns: new[] { "IdTemporadaNavigationIdAnime", "IdTemporadaNavigationIdTemporada" },
                principalTable: "Temporadas",
                principalColumns: new[] { "id_anime", "id_temporada" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Temporadas_Temporadas_IdTemporadaNavigationIdAnime_IdTemporadaNavigationIdTemporada",
                table: "Temporadas",
                columns: new[] { "IdTemporadaNavigationIdAnime", "IdTemporadaNavigationIdTemporada" },
                principalTable: "Temporadas",
                principalColumns: new[] { "id_anime", "id_temporada" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historial_Temporadas_IdTemporadaNavigationIdAnime_IdTemporadaNavigationIdTemporada",
                table: "Historial");

            migrationBuilder.DropForeignKey(
                name: "FK_Temporadas_Temporadas_IdTemporadaNavigationIdAnime_IdTemporadaNavigationIdTemporada",
                table: "Temporadas");

            migrationBuilder.DropIndex(
                name: "IX_Temporadas_IdTemporadaNavigationIdAnime_IdTemporadaNavigationIdTemporada",
                table: "Temporadas");

            migrationBuilder.DropIndex(
                name: "IX_Historial_IdTemporadaNavigationIdAnime_IdTemporadaNavigationIdTemporada",
                table: "Historial");

            migrationBuilder.DropColumn(
                name: "IdTemporadaNavigationIdAnime",
                table: "Temporadas");

            migrationBuilder.DropColumn(
                name: "IdTemporadaNavigationIdTemporada",
                table: "Temporadas");

            migrationBuilder.DropColumn(
                name: "IdTemporadaNavigationIdAnime",
                table: "Historial");

            migrationBuilder.DropColumn(
                name: "IdTemporadaNavigationIdTemporada",
                table: "Historial");
        }
    }
}
