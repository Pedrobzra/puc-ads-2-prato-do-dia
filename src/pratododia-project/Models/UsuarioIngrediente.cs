using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pratododia_project.Models
{
    [Table("UsuarioIngredientes")]
    [PrimaryKey(nameof(IdUsuario), nameof(IdIngrediente))]
    public class UsuarioIngrediente
    {
       
        public int IdIngrediente { get; set; }

        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        [ForeignKey("IdIngrediente")]
        public Ingrediente Ingrediente { get; set; }

        public bool Status { get; set; }
    }
}
