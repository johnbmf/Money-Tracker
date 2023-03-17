using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Money_Tracker.Models
{
    public class Transaccion
    {
        [Key] public int transaccionId { get; set; }

        public int categoriaID { get; set; }
        public Categoria? categoria { get; set; }
        public int transaccionMonto { get; set; }
        [Column(TypeName = "nvarchar(75)")] public string? transaccionDescripcion { get; set; }
        public DateTime transaccionFecha { get; set; } = DateTime.Now;
        [NotMapped] public string? categoriaIconoNombre {
            get {
                return categoria == null ? "" : categoria.categoriaIcono + "" + categoria.categoriaNombre;
            }
        }

        [NotMapped]
        public string? transaccionMontoFormat
        {
            get
            {
                return ((categoria == null || categoria.categoriaTipo == "Egreso") ? "- " : "+ ") + transaccionMonto.ToString("C0");
            }
        }
    }
}
