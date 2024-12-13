using pratododia_project.Models;

namespace pratododia_project.ViewModels
{
    public class MinhasReceitasVM
    {

        public ICollection<Receita> ReceitasCriadas { get; set; }

        public int idReceita { get; set; }

        public ICollection<SavedRecipe> ReceitasSalvas { get; set; }

        public List<DateTime> ReceitasPlanejadas { get; set; }

        public ICollection<Receita> ReceitasPlanejadasUsuario { get; set; }

    }
}
