using Microsoft.EntityFrameworkCore;

namespace pratododia_project.Models
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Receita> Receitas { get; set; }

        public DbSet<Ingrediente> Ingredientes { get; set; }

        public DbSet<Comentario> Comentarios { get; set; }

        public DbSet<PlannedRecipe> PlannedRecipes { get; set; }

        public DbSet<SavedRecipe> SavedRecipes { get; set; }

        public DbSet<RatedRecipe> RatedRecipes { get; set; }

        public DbSet<RespostaComentario> RespostasComentario { get; set; }

        public DbSet<UsuarioIngrediente> UsuarioIngredientes { get; set; }

        public DbSet<IngredienteReceita> IngredientesReceitas { get; set; }
    }
}