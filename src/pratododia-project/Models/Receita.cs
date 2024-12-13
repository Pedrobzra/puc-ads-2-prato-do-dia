using pratododia_project.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pratododia_project.Models
{
    [Table("Receitas")]
    public class Receita
  {
        [Key]
        public int IdReceita { get; set; }

        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; private set; }

        public DateTime DataPublicacao { get; set; }

        public string CaminhoImg { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string NomeReceita { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public TimeSpan TempoPreparo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public TipoDificuldade Dificuldade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public int Rendimento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public TipoReceita Categoria { get; set; }

        public int NumCurtidas { get; set; }

        public float Avaliacao { get; set; }

        public int Acessos { get; set; }

        public ICollection<IngredienteReceita> IngredientesReceitas { get; set; }

        public ICollection<PlannedRecipe> PlannedRecipes { get; set; }

        public ICollection<SavedRecipe> SavedRecipes { get; set; }

        public ICollection<Comentario> Comentarios { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public List<string> Passos { get; set; }
    }

    public enum TipoDificuldade
    {
     Iniciante,
     Intermediário,
     Avançado
    }

    public enum TipoReceita
    {
     Massas_e_Pizzas,
     Sobremesas,
     Sopas_e_Caldos,
     Saladas,
     Prato_Principal,
     Lanche,
     Saudável,
     Proteico,
     Entradas,
     Bebidas,
     Acompanhamentos

    }
}