using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pratododia_project.Models
{
    [Table("RatedRecipe")]
    [PrimaryKey(nameof(IdUsuario), nameof(IdReceita))]
    public class RatedRecipe
    {
        public int IdUsuario { get; set; }

        public int IdReceita { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        [ForeignKey("IdReceita")]
        public Receita Receita { get; set; }

        public int Nota { get; set; }
    }
}
