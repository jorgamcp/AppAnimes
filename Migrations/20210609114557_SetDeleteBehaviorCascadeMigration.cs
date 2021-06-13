using Microsoft.EntityFrameworkCore.Migrations;

namespace AppAnimes.Migrations
{
    public partial class SetDeleteBehaviorCascadeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historial_Animes",
                table: "Historial");

            migrationBuilder.DropForeignKey(
                name: "FK_Historial_Temporadas",
                table: "Historial");

            migrationBuilder.DropForeignKey(
                name: "FK_Temporadas_Animes",
                table: "Temporadas");

            migrationBuilder.AlterColumn<int>(
                name: "AnimeId",
                table: "Historial",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Historial_Animes",
                table: "Historial",
                column: "AnimeId",
                principalTable: "Animes",
                principalColumn: "AnimeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Historial_Temporadas",
                table: "Historial",
                column: "TemporadaId",
                principalTable: "Temporadas",
                principalColumn: "TemporadaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Temporadas_Animes",
                table: "Temporadas",
                column: "AnimeId",
                principalTable: "Animes",
                principalColumn: "AnimeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historial_Animes",
                table: "Historial");

            migrationBuilder.DropForeignKey(
                name: "FK_Historial_Temporadas",
                table: "Historial");

            migrationBuilder.DropForeignKey(
                name: "FK_Temporadas_Animes",
                table: "Temporadas");

            migrationBuilder.AlterColumn<int>(
                name: "AnimeId",
                table: "Historial",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Historial_Animes",
                table: "Historial",
                column: "AnimeId",
                principalTable: "Animes",
                principalColumn: "AnimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Historial_Temporadas",
                table: "Historial",
                column: "TemporadaId",
                principalTable: "Temporadas",
                principalColumn: "TemporadaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Temporadas_Animes",
                table: "Temporadas",
                column: "AnimeId",
                principalTable: "Animes",
                principalColumn: "AnimeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
