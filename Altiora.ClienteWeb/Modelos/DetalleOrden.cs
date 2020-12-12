namespace Altiora.ClienteWeb.Modelos
{
    /// <summary>
    /// Dto que almacena el detalle de la orden
    /// </summary>
    public class DetalleOrden
    {
        public int IdDetalleOrden { get; set; }
        public int IdOrden { get; set; }
        public Orden Orden { get; set; }
        public int IdArticulo { get; set; }
        public Articulo Articulo { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioTotal { get; set; }
    }
}
