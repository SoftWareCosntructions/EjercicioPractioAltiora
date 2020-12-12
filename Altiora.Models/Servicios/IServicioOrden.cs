using Altiora.Models.Data;
using Altiora.Models.Respuestas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Altiora.Models.Servicios
{
    /// <summary>
    /// Interfaz para servicio de Ordenes
    /// </summary>
    public interface IServicioOrden
    {
        Task<IEnumerable<RespuestaOrden>> ObtenerTodos();
        Task<RespuestaOrden> ObtenerOrdenPorId(int id);
        Task CrearOrden(Orden nuevaOrden);
        Task ActualizarOrden(Orden ordenAActualizar, Orden orden);
        Task EliminarOrden(int id);
    }
}
