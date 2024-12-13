using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pratododia_project.Migrations
{
    /// <inheritdoc />
    public partial class M20UpdateEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RespostasComentario_Comentarios_IdComentario",
                table: "RespostasComentario");

            migrationBuilder.DropForeignKey(
                name: "FK_RespostasComentario_Usuarios_IdUsuario",
                table: "RespostasComentario");

            migrationBuilder.AlterColumn<int>(
                name: "IdUsuario",
                table: "RespostasComentario",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdComentario",
                table: "RespostasComentario",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RespostasComentario_Comentarios_IdComentario",
                table: "RespostasComentario",
                column: "IdComentario",
                principalTable: "Comentarios",
                principalColumn: "IdComentário",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RespostasComentario_Usuarios_IdUsuario",
                table: "RespostasComentario",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RespostasComentario_Comentarios_IdComentario",
                table: "RespostasComentario");

            migrationBuilder.DropForeignKey(
                name: "FK_RespostasComentario_Usuarios_IdUsuario",
                table: "RespostasComentario");

            migrationBuilder.AlterColumn<int>(
                name: "IdUsuario",
                table: "RespostasComentario",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdComentario",
                table: "RespostasComentario",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_RespostasComentario_Comentarios_IdComentario",
                table: "RespostasComentario",
                column: "IdComentario",
                principalTable: "Comentarios",
                principalColumn: "IdComentário");

            migrationBuilder.AddForeignKey(
                name: "FK_RespostasComentario_Usuarios_IdUsuario",
                table: "RespostasComentario",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario");
        }
    }
}
