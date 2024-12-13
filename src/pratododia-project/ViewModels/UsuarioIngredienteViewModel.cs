using pratododia_project.Models;

namespace pratododia_project.ViewModels
{
    public class UsuarioIngredienteViewModel
    {
        public Usuario Usuario { get; set; }

        public ICollection<Ingrediente> Ingredientes { get; set; }

        public List<UsuarioIngrediente> UsuarioIngrediente { get; set; } = new List<UsuarioIngrediente>();

        public List<TipoRestricao> Dieta { get; set; } = new List<TipoRestricao>();

        public List<TipoRestricao> RestricoesAtivas { get; set; } = new List<TipoRestricao>();
    }
}
