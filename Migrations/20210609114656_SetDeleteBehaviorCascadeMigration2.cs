using Microsoft.EntityFrameworkCore.Migrations;

namespace AppAnimes.Migrations
{
    public partial class SetDeleteBehaviorCascadeMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Temporadas_Animes",
                table: "Temporadas");

            migrationBuilder.AddForeignKey(
                name: "FK_Temporadas_Animes",
                table: "Temporadas",
                column: "AnimeId",
                principalTable: "Animes",
                principalColumn: "AnimeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Temporadas_Animes",
                table: "Temporadas");

            migrationBuilder.AddForeignKey(
                name: "FK_Temporadas_Animes",
                table: "Temporadas",
                column: "AnimeId",
                principalTable: "Animes",
                principalColumn: "AnimeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
