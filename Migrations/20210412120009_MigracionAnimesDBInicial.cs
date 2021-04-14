using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppAnimes.Migrations
{
    public partial class MigracionAnimesDBInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animes",
                columns: table => new
                {
                    id_anime = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    genero = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    nombre_en_ingles = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animes", x => x.id_anime);
                });

            migrationBuilder.CreateTable(
                name: "Historial",
                columns: table => new
                {
                    id_historial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_anime = table.Column<int>(type: "int", nullable: false),
                    id_temp = table.Column<int>(type: "int", nullable: false),
                    fecha_inicio = table.Column<DateTime>(type: "datetime", nullable: true),
                    fecha_fin = table.Column<DateTime>(type: "datetime", nullable: true),
                    fecha_pausa = table.Column<DateTime>(type: "datetime", nullable: true),
                    visto_en = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historial", x => x.id_historial);
                    table.ForeignKey(
                        name: "FK_historial_animes",
                        column: x => x.id_anime,
                        principalTable: "Animes",
                        principalColumn: "id_anime",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Temporadas",
                columns: table => new
                {
                    id_anime = table.Column<int>(type: "int", nullable: false),
                    id_temporada = table.Column<int>(type: "int", nullable: false),
                    nombre_temporada = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    estado = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    tipo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    temporada_estreno = table.Column<string>(type: "varchar(400)", unicode: false, maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temporadas", x => new { x.id_anime, x.id_temporada });
                    table.ForeignKey(
                        name: "FK_temporadas_animes",
                        column: x => x.id_anime,
                        principalTable: "Animes",
                        principalColumn: "id_anime",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Historial_id_anime",
                table: "Historial",
                column: "id_anime");
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
