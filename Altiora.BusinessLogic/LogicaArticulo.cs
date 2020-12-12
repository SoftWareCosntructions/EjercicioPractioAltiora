using Altiora.Models;
using Altiora.Models.Data;
using Altiora.Models.Respuestas;
using Altiora.Models.Servicios;
using Mapster;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Altiora.BusinessLogic
{
    public class LogicaArticulo : IServicioArticulo
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        public LogicaArticulo(IUnidadDeTrabajo unidadDeTrabajo)
        {
            this._unidadDeTrabajo = unidadDeTrabajo;
        }
        public async Task ActualizarArticulo(Articulo ArticuloAActualizar, Articulo Articulo)
        {
            _unidadDeTrabajo.Articulos.Actualizar(ArticuloAActualizar);
            await _unidadDeTrabajo.CommitAsync();
        }

        public async Task<Articulo> CrearArticulo(Articulo nuevoArticulo)
        {
            await _unidadDeTrabajo.Articulos.InsertarAsync(nuevoArticulo);
            await _unidadDeTrabajo.CommitAsync();
            return nuevoArticulo;
        }

        public async Task EliminarArticulo(Articulo Articulo)
        {
            _unidadDeTrabajo.Articulos.Eliminar(Articulo);
            await _unidadDeTrabajo.CommitAsync();
        }

        public async Task<RespuestaArticulo> ObtenerArticuloPorId(int id)
        {
            Articulo articulo = await _unidadDeTrabajo.Articulos.ObtenerArticuloPorId(id);
            return articulo.Adapt<RespuestaArticulo>();
        }

        public async Task<IEnumerable<RespuestaArticulo>> ObtenerTodos()
        {
            IEnumerable<Articulo> articulos = await _unidadDeTrabajo.Articulos.ObtenerTodos();
            return articulos.Adapt<IEnumerable<RespuestaArticulo>>();
        }
    }
}
