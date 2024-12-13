using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pratododia_project.Models
{

    [Table("IngredientesReceitas")]
    [PrimaryKey(nameof(IdReceita), nameof(IdIngrediente))]
    public class IngredienteReceita
    {
        public int IdReceita { get; set; }

        [ForeignKey("IdReceita")]
        public Receita Receita { get; set; }

        public int IdIngrediente { get; set; }

        [ForeignKey("IdIngrediente")]
        public Ingrediente Ingrediente { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public TipoQuantidade Tipo { get; set; }

    }
    public enum TipoQuantidade
    {
        Litros,
        Mililitros,
        Quilos,
        Gramas,
        Xícaras,
        Colheres_de_Sopa,
        Colheres_de_Chá,
        Colheres_de_Café,
        Copos,
        Unidades,
        a_gosto
    }
}