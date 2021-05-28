using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppAnimes.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animes",
                columns: table => new
                {
                    AnimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Genero = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NombreIngles = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animes", x => x.AnimeId);
                });

            migrationBuilder.CreateTable(
                name: "Temporadas",
                columns: table => new
                {
                    TemporadaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroTemporada = table.Column<int>(type: "int", nullable: true),
                    NombreTemporada = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Estado = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    tipo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TemporadaEstreno = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    AnimeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temporadas", x => x.TemporadaId);
                    table.ForeignKey(
                        name: "FK_Temporadas_Animes",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "AnimeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Historial",
                columns: table => new
                {
                    id_historial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimeId = table.Column<int>(type: "int", nullable: false),
                    TemporadaId = table.Column<int>(type: "int", nullable: true),
                    FechaInicio = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaFin = table.Column<DateTime>(type: "datetime", nullable: true),
                    VistoEn = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historial", x => x.id_historial);
                    table.ForeignKey(
                        name: "FK_Historial_Animes",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "AnimeId");
                    table.ForeignKey(
                        name: "FK_Historial_Temporadas",
                        column: x => x.TemporadaId,
                        principalTable: "Temporadas",
                        principalColumn: "TemporadaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Historial_AnimeId",
                table: "Historial",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Historial_TemporadaId",
                table: "Historial",
                column: "TemporadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Temporadas_AnimeId",
                table: "Temporadas",
                column: "AnimeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Historial");

            migrationBuilder.DropTable(
                name: "Temporadas");

            migrationBuilder.DropTable(
                name: "Animes");
        }
    }
}
