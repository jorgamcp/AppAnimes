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
                    Genero = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    NombreIngles = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animes", x => x.AnimeId);
                });

            migrationBuilder.CreateTable(
                name: "Paginas",
                columns: table => new
                {
                    paginaId = table.Column<int>(type: "int", unicode: false, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombrePagina = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    esLegal = table.Column<bool>(type: "bit", nullable: false),
                    esFansub = table.Column<bool>(type: "bit", nullable: false),
                    estaDisponible = table.Column<bool>(type: "bit", nullable: false),
                    estaActivo = table.Column<bool>(type: "bit", nullable: false),
                    urlPagina = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paginas", x => x.paginaId);
                });

            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    PeliculaId = table.Column<int>(type: "int", unicode: false, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombrePelicula = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    estudio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AnimeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.PeliculaId);
                    table.ForeignKey(
                        name: "FK_Peliculas_Animes_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "AnimeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Temporadas",
                columns: table => new
                {
                    TemporadaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroTemporada = table.Column<int>(type: "int", nullable: true),
                    NombreTemporada = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Estado = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    tipo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    TemporadaEstreno = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    AnimeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temporadas", x => x.TemporadaId);
                    table.ForeignKey(
                        name: "FK_Temporadas_Animes",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "AnimeId");
                });

            migrationBuilder.CreateTable(
                name: "Historial",
                columns: table => new
                {
                    id_historial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemporadaId = table.Column<int>(type: "int", nullable: true),
                    FechaInicio = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaFin = table.Column<DateTime>(type: "datetime", nullable: true),
                    VistoEn = table.Column<int>(type: "int", unicode: false, maxLength: 50, nullable: false),
                    AnyoVisto = table.Column<int>(type: "int", nullable: true),
                    AnimeId = table.Column<int>(type: "int", nullable: true),
                    PeliculasPeliculaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historial", x => x.id_historial);
                    table.ForeignKey(
                        name: "FK_Historial_Animes_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "AnimeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Historial_Paginas_VistoEn",
                        column: x => x.VistoEn,
                        principalTable: "Paginas",
                        principalColumn: "paginaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Historial_Peliculas_PeliculasPeliculaId",
                        column: x => x.PeliculasPeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "PeliculaId",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_Historial_PeliculasPeliculaId",
                table: "Historial",
                column: "PeliculasPeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_Historial_TemporadaId",
                table: "Historial",
                column: "TemporadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Historial_VistoEn",
                table: "Historial",
                column: "VistoEn");

            migrationBuilder.CreateIndex(
                name: "IX_Peliculas_AnimeId",
                table: "Peliculas",
                column: "AnimeId");

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
                name: "Paginas");

            migrationBuilder.DropTable(
                name: "Peliculas");

            migrationBuilder.DropTable(
                name: "Temporadas");

            migrationBuilder.DropTable(
                name: "Animes");
        }
    }
}
