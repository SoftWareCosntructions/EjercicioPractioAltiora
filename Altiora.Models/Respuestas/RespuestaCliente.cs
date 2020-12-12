using System;
using System.Collections.Generic;

namespace Altiora.Models.Respuestas
{
    public class RespuestaCliente
    {
        public int IdCliente { get; set; }
        public string DniCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public IEnumerable<OrdenRespuestaCliente> Ordenes { get; set; }
    }

    public class OrdenRespuestaCliente
    {
        public int IdOrden { get; set; }
        public DateTime FechaOrden { get; set; }
        public int IdCliente { get; set; }
        public string NumeroOrden { get; set; }
        public decimal Subtotal { get; set; }
        public decimal MontoIva { get; set; }
        public decimal MontoTotal { get; set; }
        public IEnumerable<DetalleOrdenRespuestaCliente> DetallesOrden { get; set; }
    }

    public class DetalleOrdenRespuestaCliente
    {
        public int IdDetalleOrden { get; set; }
        public int IdOrden { get; set; }
        public int IdArticulo { get; set; }
        public RespuestaArticulo Articulo { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioTotal { get; set; }
    }
}
