using System.Collections.Generic;

namespace Altiora.ClienteWeb.Modelos
{
    /// <summary>
    /// Dto información del cliente
    /// </summary>
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string DniCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public IEnumerable<Orden> Ordenes { get; set; }
    }
}
