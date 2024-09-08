using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Faculdade.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Curso",
                table: "Estudantes");

            migrationBuilder.AddColumn<int>(
                name: "CursoId",
                table: "Estudantes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Estudantes_CursoId",
                table: "Estudantes",
                column: "CursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estudantes_Cursos_CursoId",
                table: "Estudantes",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "CursoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudantes_Cursos_CursoId",
                table: "Estudantes");

            migrationBuilder.DropIndex(
                name: "IX_Estudantes_CursoId",
                table: "Estudantes");

            migrationBuilder.DropColumn(
                name: "CursoId",
                table: "Estudantes");

            migrationBuilder.AddColumn<string>(
                name: "Curso",
                table: "Estudantes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
