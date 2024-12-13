using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pratododia_project.Migrations
{
    /// <inheritdoc />
    public partial class M04AlterTablesReceitaUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "categoria",
                table: "Receitas",
                newName: "Categoria");

            migrationBuilder.RenameColumn(
                name: "restricao",
                table: "Ingredientes",
                newName: "Restricao");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Ingredientes",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "categoria",
                table: "Ingredientes",
                newName: "Categoria");

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Receitas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Receitas_IdUsuario",
                table: "Receitas",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Receitas_Usuarios_IdUsuario",
                table: "Receitas",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receitas_Usuarios_IdUsuario",
                table: "Receitas");

            migrationBuilder.DropIndex(
                name: "IX_Receitas_IdUsuario",
                table: "Receitas");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Receitas");

            migrationBuilder.RenameColumn(
                name: "Categoria",
                table: "Receitas",
                newName: "categoria");

            migrationBuilder.RenameColumn(
                name: "Restricao",
                table: "Ingredientes",
                newName: "restricao");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Ingredientes",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Categoria",
                table: "Ingredientes",
                newName: "categoria");
        }
    }
}
