using Altiora.Models.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Altiora.Models.Repositorios
{
    /// <summary>
    /// Interfaz para repositorio de Orden
    /// </summary>
    public interface IRepositorioOrden : IRepositorio<Orden>
    {
        /// <summary>
        /// Obtiene la lista de todos las ordenes que existen en la base de datos
        /// </summary>
        /// <returns>Lista del objeto orden resultado de la consulta</returns>
        Task<IEnumerable<Orden>> ObtenerTodos();
        /// <summary>
        /// Obtiene el cliente que el campo IdOrden coincide con el parametro id ingresado
        /// </summary>
        /// <param name="id">Id de la orden</param>
        /// <returns>objeto resultado de la consulta</returns>
        Task<Orden> ObtenerOrdenPorId(int id);
        /// <summary>
        /// Inserta objeto Orden
        /// </summary>
        /// <param name="entidad">Datos para insertar registro</param>
        /// <returns>Tarea</returns>
        Task InsertarOrden(Orden entidad);
        /// <summary>
        /// Actualiza objeto Orden
        /// </summary>
        /// <param name="entidad">Datos para actualiza registro</param>
        /// <returns>Tarea</returns>
        Task ActualizarOrden(Orden entidad);
        /// <summary>
        /// Eliminar Orden
        /// </summary>
        /// <param name="entidad"></param>
        void EliminarOrden(Orden entidad);
    }
}
