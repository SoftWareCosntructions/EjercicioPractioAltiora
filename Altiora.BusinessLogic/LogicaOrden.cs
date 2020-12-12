using Altiora.Models;
using Altiora.Models.Data;
using Altiora.Models.Respuestas;
using Altiora.Models.Servicios;
using Mapster;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Altiora.BusinessLogic
{
    public class LogicaOrden : IServicioOrden
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        public LogicaOrden(IUnidadDeTrabajo unidadDeTrabajo)
        {
            this._unidadDeTrabajo = unidadDeTrabajo;
        }
        public async Task ActualizarOrden(Orden ordenAActualizar, Orden orden)
        {
            _unidadDeTrabajo.Ordenes.Actualizar(ordenAActualizar);
            await _unidadDeTrabajo.CommitAsync();
        }

        public async Task CrearOrden(Orden nuevaOrden)
        {
            await _unidadDeTrabajo.Ordenes.InsertarAsync(nuevaOrden);
            await _unidadDeTrabajo.CommitAsync();
        }

        public async Task EliminarOrden(int Id)
        {
            Orden orden = await _unidadDeTrabajo.Ordenes.ObtenerOrdenPorId(Id);
            _unidadDeTrabajo.Ordenes.Eliminar(orden);
            await _unidadDeTrabajo.CommitAsync();
        }

        public async Task<RespuestaOrden> ObtenerOrdenPorId(int id)
        {
            Orden orden = await _unidadDeTrabajo.Ordenes.ObtenerOrdenPorId(id);
            return orden.Adapt<RespuestaOrden>();
        }

        public async Task<IEnumerable<RespuestaOrden>> ObtenerTodos()
        {
            IEnumerable<Orden> ordenes = await _unidadDeTrabajo.Ordenes.ObtenerTodos();
            return ordenes.Adapt<IEnumerable<RespuestaOrden>>();
        }

    }
}
