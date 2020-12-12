using Altiora.Models.Data;
using Altiora.Models.Respuestas;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Altiora.Models.Servicios
{
    /// <summary>
    /// Interfaz para servicio de Artículo
    /// </summary>
    public interface IServicioArticulo
    {
        Task<IEnumerable<RespuestaArticulo>> ObtenerTodos();
        Task<RespuestaArticulo> ObtenerArticuloPorId(int id);
        Task<Articulo> CrearArticulo(Articulo nuevaArticulo);
        Task ActualizarArticulo(Articulo ArticuloAActualizar, Articulo Articulo);
        Task EliminarArticulo(Articulo Articulo);
    }
}
