using Microsoft.EntityFrameworkCore.Migrations;

namespace AppAnimes.Migrations
{
    public partial class AddedEstaActivoColumnToPaginasTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historial_Paginas_PaginaspaginaId",
                table: "Historial");

            migrationBuilder.RenameColumn(
                name: "PaginaspaginaId",
                table: "Historial",
                newName: "paginaId");

            migrationBuilder.RenameIndex(
                name: "IX_Historial_PaginaspaginaId",
                table: "Historial",
                newName: "IX_Historial_paginaId");

            migrationBuilder.AddColumn<bool>(
                name: "estaActivo",
                table: "Paginas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "VistoEn",
                table: "Historial",
                type: "int",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_Historial_Paginas_paginaId",
                table: "Historial",
                column: "paginaId",
                principalTable: "Paginas",
                principalColumn: "paginaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historial_Paginas_paginaId",
                table: "Historial");

            migrationBuilder.DropColumn(
                name: "estaActivo",
                table: "Paginas");

            migrationBuilder.RenameColumn(
                name: "paginaId",
                table: "Historial",
                newName: "PaginaspaginaId");

            migrationBuilder.RenameIndex(
                name: "IX_Historial_paginaId",
                table: "Historial",
                newName: "IX_Historial_PaginaspaginaId");

            migrationBuilder.AlterColumn<string>(
                name: "VistoEn",
                table: "Historial",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_Historial_Paginas_PaginaspaginaId",
                table: "Historial",
                column: "PaginaspaginaId",
                principalTable: "Paginas",
                principalColumn: "paginaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
