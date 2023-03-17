using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Money_Tracker.Models
{
    public class Categoria
    {
        [Key] public int categoriaId { get; set; }    
        [Column(TypeName = "nvarchar(30)")] public string categoriaNombre { get; set; }
        [Column(TypeName = "nvarchar(30)")] public string categoriaIcono { get; set; } = "";
        [Column(TypeName = "nvarchar(30)")] public string categoriaTipo { get; set; } = "Egreso";
        [NotMapped] public string? categoriaIconoNombre {
            get
            {
                return this.categoriaIcono + " " + this.categoriaNombre;
            }
        }

    }
}
