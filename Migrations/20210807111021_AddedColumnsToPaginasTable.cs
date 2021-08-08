using Microsoft.EntityFrameworkCore.Migrations;

namespace AppAnimes.Migrations
{
    public partial class AddedColumnsToPaginasTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "nombrePagina",
                table: "Paginas",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "esFansub",
                table: "Paginas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "urlPagina",
                table: "Paginas",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "esFansub",
                table: "Paginas");

            migrationBuilder.DropColumn(
                name: "urlPagina",
                table: "Paginas");

            migrationBuilder.AlterColumn<string>(
                name: "nombrePagina",
                table: "Paginas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);
        }
    }
}
