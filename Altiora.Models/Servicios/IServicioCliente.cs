using Altiora.Models.Data;
using Altiora.Models.Respuestas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Altiora.Models.Servicios
{
    /// <summary>
    /// Interfaz para servicio de Clientes
    /// </summary>
    public interface IServicioCliente
    {
        Task<IEnumerable<RespuestaCliente>> ObtenerTodos();
        Task<RespuestaCliente> ObtenerClientePorId(int id);
        Task<Cliente> CrearCliente(Cliente nuevoCliente);
        Task ActualizarCliente(Cliente clienteAActualizar, Cliente Cliente);
        Task EliminarCliente(int Id);
    }
}
