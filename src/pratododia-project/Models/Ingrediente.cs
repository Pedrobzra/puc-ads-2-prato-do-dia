using pratododia_project.Controllers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pratododia_project.Models
{
    [Table("Ingredientes")]
    public class Ingrediente
    {
        [Key]
        public int IdIngrediente { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        public TipoIngrediente Categoria { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        public TipoRestricao Restricao { get; set; }

        public ICollection<IngredienteReceita> IngredientesReceitas { get; set; }

        public ICollection<UsuarioIngrediente> UsuarioIngredientes { get; set; }

        public bool TemRestricao(TipoRestricao restricao)
        {
            return (Restricao & restricao) == restricao;
        }
    }

    public enum TipoIngrediente
    {
        Frutas,
        Vegetais_e_Sementes,
        Grãos_e_Cereais,
        Laticínios_e_Derivados,
        Carnes_e_Peixes,
        Temperos_e_Molhos,
        Doces_e_Sobremesas,
        Bebidas,
        Massas_e_Pães,
        Óleos_e_Gorduras,
        Frutos_do_Mar,
        Outros
    }

    [Flags]
    public enum TipoRestricao
    {
        Vegetariano = 1,
        Vegano = 2,
        Sem_Lactose = 4,
        Sem_Glúten = 8,
        Sem_Açúcar = 16
    }
}