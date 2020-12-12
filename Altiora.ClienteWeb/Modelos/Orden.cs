using System;
using System.Collections.Generic;

namespace Altiora.ClienteWeb.Modelos
{
    /// <summary>
    /// Dto para almacenar los datos de las ordenes
    /// </summary>
    public class Orden
    {
        public int IdOrden { get; set; }
        public DateTime FechaOrden { get; set; }
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        public string NumeroOrden { get; set; }
        public decimal Subtotal { get; set; }
        public decimal MontoIva { get; set; }
        public decimal MontoTotal { get; set; }
        public IEnumerable<DetalleOrden> DetallesOrden { get; set; }
    }
}
