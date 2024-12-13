using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pratododia_project.Models
{
    [Table("RespostasComentario")]
    public class RespostaComentario
    {
        [Key]
        public int IdResposta { get; set; }
        public int IdComentario { get; set; }
        [ForeignKey("IdComentario")]
        public Comentario Comentario { get; set; }
        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        public string Texto { get; set; }

        public int NumCurtidas { get; set; }
		public DateTime DataResposta { get; set; }

	}
}
