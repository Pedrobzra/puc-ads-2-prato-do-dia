using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pratododia_project.Migrations
{
    /// <inheritdoc />
    public partial class M05AddAllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    IdComentário = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdReceita = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Texto = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataComentario = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    NumCurtidas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.IdComentário);
                    table.ForeignKey(
                        name: "FK_Comentarios_Receitas_IdReceita",
                        column: x => x.IdReceita,
                        principalTable: "Receitas",
                        principalColumn: "IdReceita",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comentarios_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateTable(
                name: "IngredienteUsuario",
                columns: table => new
                {
                    IngredientesIdIngrediente = table.Column<int>(type: "int", nullable: false),
                    UsuariosIdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredienteUsuario", x => new { x.IngredientesIdIngrediente, x.UsuariosIdUsuario });
                    table.ForeignKey(
                        name: "FK_IngredienteUsuario_Ingredientes_IngredientesIdIngrediente",
                        column: x => x.IngredientesIdIngrediente,
                        principalTable: "Ingredientes",
                        principalColumn: "IdIngrediente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredienteUsuario_Usuarios_UsuariosIdUsuario",
                        column: x => x.UsuariosIdUsuario,
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
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdReceita = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "UsuarioIngredientes",
                columns: table => new
                {
                    IdIngrediente = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioIngredientes", x => new { x.IdUsuario, x.IdIngrediente });
                    table.ForeignKey(
                        name: "FK_UsuarioIngredientes_Ingredientes_IdIngrediente",
                        column: x => x.IdIngrediente,
                        principalTable: "Ingredientes",
                        principalColumn: "IdIngrediente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioIngredientes_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RespostasComentario",
                columns: table => new
                {
                    IdResposta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdComentario = table.Column<int>(type: "int", nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: true),
                    Texto = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataResposta = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    NumCurtidas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespostasComentario", x => x.IdResposta);
                    table.ForeignKey(
                        name: "FK_RespostasComentario_Comentarios_IdComentario",
                        column: x => x.IdComentario,
                        principalTable: "Comentarios",
                        principalColumn: "IdComentário");
                    table.ForeignKey(
                        name: "FK_RespostasComentario_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_IdReceita",
                table: "Comentarios",
                column: "IdReceita");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_IdUsuario",
                table: "Comentarios",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_IngredienteReceita_ReceitasIdReceita",
                table: "IngredienteReceita",
                column: "ReceitasIdReceita");

            migrationBuilder.CreateIndex(
                name: "IX_IngredienteUsuario_UsuariosIdUsuario",
                table: "IngredienteUsuario",
                column: "UsuariosIdUsuario");

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

            migrationBuilder.CreateIndex(
                name: "IX_RespostasComentario_IdComentario",
                table: "RespostasComentario",
                column: "IdComentario");

            migrationBuilder.CreateIndex(
                name: "IX_RespostasComentario_IdUsuario",
                table: "RespostasComentario",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioIngredientes_IdIngrediente",
                table: "UsuarioIngredientes",
                column: "IdIngrediente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredienteReceita");

            migrationBuilder.DropTable(
                name: "IngredienteUsuario");

            migrationBuilder.DropTable(
                name: "ReceitasPlanejadas");

            migrationBuilder.DropTable(
                name: "ReceitasSalvas");

            migrationBuilder.DropTable(
                name: "RespostasComentario");

            migrationBuilder.DropTable(
                name: "UsuarioIngredientes");

            migrationBuilder.DropTable(
                name: "Comentarios");
        }
    }
}
