using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Altiora.Models.Data
{
    /// <summary>
    /// Dto información del cliente
    /// </summary>
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        [MaxLength(20)]
        public string DniCliente { get; set; }
        [MaxLength(50)]
        public string Nombre { get; set; }
        [MaxLength(50)]
        public string Apellido { get; set; }

        public IEnumerable<Orden> Ordenes { get; set; }
    }
}
