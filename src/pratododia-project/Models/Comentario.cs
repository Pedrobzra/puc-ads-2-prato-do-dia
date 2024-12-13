using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pratododia_project.Models
{
    [Table("Comentarios")]
    public class Comentario
    {
        [Key]
        public int IdComentário { get; set; }

        public int IdReceita { get; set; }

        [ForeignKey("IdReceita")]
        public Receita Receita { get; set; }

        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        public string Texto { get; set; }

        public DateTime DataComentario { get; set; }

        public int NumCurtidas { get; set; }
        //public ICollection<Usuario> UsuariosCurtiram { get; set; }

        public ICollection<RespostaComentario> RespostasComentario { get; set; }
    }
}
