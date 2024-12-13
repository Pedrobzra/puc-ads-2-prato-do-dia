using pratododia_project.Models;

namespace pratododia_project.ViewModels
{
    public class ReceitaVM
    {
        public Usuario Usuario {  get; set; }
        public Receita Receita { get; set; }
        public bool eSalva { get; set; }
        public int MinhaNota { get; set; }
        public List<string> Passo { get; internal set; }
        public List<IngredienteReceita> Ingredientes { get; set; }
        public List<Comentario> Comentarios { get; set; }
        public List<Receita> ReceitaMaisComentadas { get; set; }
        public List<Receita> ReceitaMaisVistas { get; set; }
        public List<Receita> ReceitaMaisAvaliadas{ get; set; }
    }
}
