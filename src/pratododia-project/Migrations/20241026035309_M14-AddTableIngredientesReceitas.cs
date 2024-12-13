using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pratododia_project.Migrations
{
    /// <inheritdoc />
    public partial class M14AddTableIngredientesReceitas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredienteReceita");

            migrationBuilder.CreateTable(
                name: "IngredientesReceitas",
                columns: table => new
                {
                    IdReceita = table.Column<int>(type: "int", nullable: false),
                    IdIngrediente = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientesReceitas", x => new { x.IdReceita, x.IdIngrediente });
                    table.ForeignKey(
                        name: "FK_IngredientesReceitas_Ingredientes_IdIngrediente",
                        column: x => x.IdIngrediente,
                        principalTable: "Ingredientes",
                        principalColumn: "IdIngrediente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientesReceitas_Receitas_IdReceita",
                        column: x => x.IdReceita,
                        principalTable: "Receitas",
                        principalColumn: "IdReceita",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientesReceitas_IdIngrediente",
                table: "IngredientesReceitas",
                column: "IdIngrediente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientesReceitas");

            migrationBuilder.CreateTable(
                name: "IngredienteReceita",
                columns: table => new
                {
                    IngredientesIdIngrediente = table.Column<int>(type: "int", nullable: false),
                    ReceitasIdReceita = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredienteReceita", x => new { x.IngredientesIdIngrediente, x.ReceitasIdReceita });
                    table.ForeignKey(
                        name: "FK_IngredienteReceita_Ingredientes_IngredientesIdIngrediente",
                        column: x => x.IngredientesIdIngrediente,
                        principalTable: "Ingredientes",
                        principalColumn: "IdIngrediente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredienteReceita_Receitas_ReceitasIdReceita",
                        column: x => x.ReceitasIdReceita,
                        principalTable: "Receitas",
                        principalColumn: "IdReceita",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_IngredienteReceita_ReceitasIdReceita",
                table: "IngredienteReceita",
                column: "ReceitasIdReceita");
        }
    }
}
