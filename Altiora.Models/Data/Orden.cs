using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Altiora.Models.Data
{
    /// <summary>
    /// Dto para almacenar los datos de las ordenes
    /// </summary>
    public class Orden
    {
        [Key]
        public int IdOrden { get; set; }
        public DateTime FechaOrden { get; set; }
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        [MaxLength(20)]
        public string NumeroOrden { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Subtotal { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal MontoIva { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal MontoTotal { get; set; }
        public IEnumerable<DetalleOrden> DetallesOrden { get; set; }
    }
}
