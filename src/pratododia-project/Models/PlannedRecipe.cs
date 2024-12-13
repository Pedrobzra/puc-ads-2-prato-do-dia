using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace pratododia_project.Models
{
    [Table("PlannedRecipe")]
    [PrimaryKey(nameof(IdUsuario), nameof(IdReceita))]
    public class PlannedRecipe
    {
        public int IdReceita { get; set; }

        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        [ForeignKey("IdReceita")]
        public Receita Receita { get; set; }

        public DateTime dataPreparo { get; set; }
    }
}
