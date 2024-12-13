using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pratododia_project.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        public string CaminhoImg {  get; set; } 

        [Required(ErrorMessage = "Campo obrigatório!")]
        [StringLength(20, ErrorMessage = "O nome deve ter no máximo 20 caracteres!")]
        [MinLength(5, ErrorMessage = "O nome deve ter no mínimo 5 caracteres!")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Não é um e-mail válido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "A senha deve conter pelo menos 8 caracteres, incluindo letras e números.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public bool IsAdmin { get; set; }

        public ICollection<Receita> Receitas { get; set; }

        public ICollection<UsuarioIngrediente> UsuarioIngredientes { get; set; }  

        public ICollection<PlannedRecipe> PlannedRecipes { get; set; }

        public ICollection<SavedRecipe> SavedRecipes { get; set; }

        public ICollection<Comentario> Comentarios { get; set; }

        public ICollection<RespostaComentario> RespostasComentario { get; set; }

    }
}
