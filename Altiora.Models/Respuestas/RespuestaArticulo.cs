using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altiora.Models.Respuestas
{
    public class RespuestaArticulo
    {
        public int IdArticulo { get; set; }
        public string CodigoArticulo { get; set; }
        public string NombreArticulo { get; set; }
        public double PrecioUnitarioArticulo { get; set; }
    }
}
