using pratododia_project.Models;
using System.ComponentModel.DataAnnotations;

namespace pratododia_project.ViewModels
{
    public class ReceitaIngredienteViewModel
    {
        public string CaminhoImg { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string NomeReceita { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Descricao { get; set; }

        public TimeSpan TempoPreparo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public TipoDificuldade Dificuldade { get; set; }

        public int Rendimento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public TipoReceita Categoria { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public List<string> Passos { get; set; }

        public ICollection<Ingrediente> Ingredientes { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public TipoQuantidade Tipo { get; set; }

        [Required(ErrorMessage = "Selecione pelo menos um ingrediente!")]
        public List<IngredienteViewModel> IngredientesSelecionados { get; set; }

        public Ingrediente Ingrediente { get; set; }
    }

    public class IngredienteViewModel
    {
            
        public int IdIngrediente { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public TipoQuantidade Tipo { get; set; }

        public string Nome { get; set; }
    }
}
