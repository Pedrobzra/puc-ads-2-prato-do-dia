using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pratododia_project.Migrations
{
    /// <inheritdoc />
    public partial class M19RenamesAndComposedFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReceitaAvaliada");

            migrationBuilder.DropTable(
                name: "ReceitasPlanejadas");

            migrationBuilder.DropTable(
                name: "ReceitasSalvas");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "UsuarioIngredientes",
                newName: "Status");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "UsuarioIngredientes",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PlannedRecipe",
                columns: table => new
                {
                    IdReceita = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    dataPreparo = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedRecipe", x => new { x.IdUsuario, x.IdReceita });
                    table.ForeignKey(
                        name: "FK_PlannedRecipe_Receitas_IdReceita",
                        column: x => x.IdReceita,
                        principalTable: "Receitas",
                        principalColumn: "IdReceita",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlannedRecipe_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RatedRecipe",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdReceita = table.Column<int>(type: "int", nullable: false),
                    Nota = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatedRecipe", x => new { x.IdUsuario, x.IdReceita });
                    table.ForeignKey(
                        name: "FK_RatedRecipe_Receitas_IdReceita",
                        column: x => x.IdReceita,
                        principalTable: "Receitas",
                        principalColumn: "IdReceita",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RatedRecipe_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SavedRecipe",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdReceita = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedRecipe", x => new { x.IdUsuario, x.IdReceita });
                    table.ForeignKey(
                        name: "FK_SavedRecipe_Receitas_IdReceita",
                        column: x => x.IdReceita,
                        principalTable: "Receitas",
                        principalColumn: "IdReceita",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SavedRecipe_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedRecipe_IdReceita",
                table: "PlannedRecipe",
                column: "IdReceita");

            migrationBuilder.CreateIndex(
                name: "IX_RatedRecipe_IdReceita",
                table: "RatedRecipe",
                column: "IdReceita");

            migrationBuilder.CreateIndex(
                name: "IX_SavedRecipe_IdReceita",
                table: "SavedRecipe",
                column: "IdReceita");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlannedRecipe");

            migrationBuilder.DropTable(
                name: "RatedRecipe");

            migrationBuilder.DropTable(
                name: "SavedRecipe");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "UsuarioIngredientes",
                newName: "status");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "UsuarioIngredientes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ReceitaAvaliada",
                columns: table => new
                {
                    IdReceitaAvaliada = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdReceita = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Nota = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceitaAvaliada", x => x.IdReceitaAvaliada);
                    table.ForeignKey(
                        name: "FK_ReceitaAvaliada_Receitas_IdReceita",
                        column: x => x.IdReceita,
                        principalTable: "Receitas",
                        principalColumn: "IdReceita",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceitaAvaliada_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ReceitasPlanejadas",
                columns: table => new
                {
                    IdReceitaPlanejada = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdReceita = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    dataPreparo = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceitasPlanejadas", x => x.IdReceitaPlanejada);
                    table.ForeignKey(
                        name: "FK_ReceitasPlanejadas_Receitas_IdReceita",
                        column: x => x.IdReceita,
                        principalTable: "Receitas",
                        principalColumn: "IdReceita",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceitasPlanejadas_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ReceitasSalvas",
                columns: table => new
                {
                    IdReceitaSalva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdReceita = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceitasSalvas", x => x.IdReceitaSalva);
                    table.ForeignKey(
                        name: "FK_ReceitasSalvas_Receitas_IdReceita",
                        column: x => x.IdReceita,
                        principalTable: "Receitas",
                        principalColumn: "IdReceita",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceitasSalvas_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ReceitaAvaliada_IdReceita",
                table: "ReceitaAvaliada",
                column: "IdReceita");

            migrationBuilder.CreateIndex(
                name: "IX_ReceitaAvaliada_IdUsuario",
                table: "ReceitaAvaliada",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_ReceitasPlanejadas_IdReceita",
                table: "ReceitasPlanejadas",
                column: "IdReceita");

            migrationBuilder.CreateIndex(
                name: "IX_ReceitasPlanejadas_IdUsuario",
                table: "ReceitasPlanejadas",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_ReceitasSalvas_IdReceita",
                table: "ReceitasSalvas",
                column: "IdReceita");

            migrationBuilder.CreateIndex(
                name: "IX_ReceitasSalvas_IdUsuario",
                table: "ReceitasSalvas",
                column: "IdUsuario");
        }
    }
}
