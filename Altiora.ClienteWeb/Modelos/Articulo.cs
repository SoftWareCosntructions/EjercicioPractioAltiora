using System.Collections.Generic;

namespace Altiora.ClienteWeb.Modelos
{
    public class Articulo
    {
        public int IdArticulo { get; set; }

        public string CodigoArticulo { get; set; }
        public string NombreArticulo { get; set; }
        public double PrecioUnitarioArticulo { get; set; }

        public IEnumerable<DetalleOrden> DetallesOrden { get; set; }
    }
}
