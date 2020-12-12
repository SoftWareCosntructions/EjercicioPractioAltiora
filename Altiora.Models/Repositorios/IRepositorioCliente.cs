using Altiora.Models.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Altiora.Models.Repositorios
{
    /// <summary>
    /// Interfaz para repositorio Cliente
    /// </summary>
    public interface IRepositorioCliente : IRepositorio<Cliente>
    {
        /// <summary>
        /// Obtiene la lista de todos los clientes que existen en la base de datos
        /// </summary>
        /// <returns>Lista del objeto cliente resultado de la consulta</returns>
        Task<IEnumerable<Cliente>> ObtenerTodos();
        /// <summary>
        /// Obtiene el cliente que el campo IdCliente coincide con el parametro id ingresado
        /// </summary>
        /// <param name="id">Id del cliente</param>
        /// <returns>objeto resultado de la consulta</returns>
        Task<Cliente> ObtenerClientePorId(int id);
        /// <summary>
        /// Inserta objeto Cliente
        /// </summary>
        /// <param name="entidad">Datos para insertar registro</param>
        /// <returns>Tarea</returns>
        void InsertarCliente(Cliente entidad);
        /// <summary>
        /// Actualiza objeto Cliente
        /// </summary>
        /// <param name="entidad">Datos para actualiza registro</param>
        /// <returns>Tarea</returns>
        void ActualizarCliente(Cliente entidad);
        /// <summary>
        /// Eliminar Cliente
        /// </summary>
        /// <param name="entidad"></param>
        void EliminarCliente(int IdCliente);
    }
}
