using pratododia_project.Models;

namespace pratododia_project.ViewModels
{
    public class IngredienteReceitaHomeViewModel
    {
        public Ingrediente Ingrediente { get; set; }
        public ICollection<Receita> Receitas { get; set; }

        public ICollection<Ingrediente> Ingredientes { get; set; }

        public ICollection<TipoIngrediente> Categorias { get; set; }

        public ICollection<TipoReceita> TipoReceitas { get; set; }
    }
}
