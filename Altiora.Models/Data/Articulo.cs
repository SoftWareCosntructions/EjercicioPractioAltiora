using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Altiora.Models.Data
{
    public class Articulo
    {
        [Key]
        public int IdArticulo { get; set; }

        [MaxLength(20)]
        public string CodigoArticulo { get; set; }
        [MaxLength(50)]
        public string NombreArticulo { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public double PrecioUnitarioArticulo { get; set; }

        public IEnumerable<DetalleOrden> DetallesOrden { get; set; }
    }
}
