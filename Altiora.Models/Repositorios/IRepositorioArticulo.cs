using Altiora.Models.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Altiora.Models.Repositorios
{
    /// <summary>
    /// Interfaz para repositorio Articulo
    /// </summary>
    public interface IRepositorioArticulo : IRepositorio<Articulo>
    {
        /// <summary>
        /// Obtiene la lista de todos los Articulos que existen en la base de datos
        /// </summary>
        /// <returns>Lista del objeto Articulo resultado de la consulta</returns>
        Task<IEnumerable<Articulo>> ObtenerTodos();
        /// <summary>
        /// Obtiene el Articulo que el campo IdArticulo coincide con el parametro id ingresado
        /// </summary>
        /// <param name="id">Id del Articulo</param>
        /// <returns>objeto resultado de la consulta</returns>
        Task<Articulo> ObtenerArticuloPorId(int id);
    }
}
