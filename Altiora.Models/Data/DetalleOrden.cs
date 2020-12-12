using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Altiora.Models.Data
{
    /// <summary>
    /// Dto que almacena el detalle de la orden
    /// </summary>
    public class DetalleOrden
    {
        [Key]
        public int IdDetalleOrden { get; set; }
        public int IdOrden { get; set; }
        public Orden Orden { get; set; }

        public int IdArticulo { get; set; }
        public Articulo Articulo { get; set; }
        public int Cantidad { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PrecioTotal { get; set; }
    }
}
