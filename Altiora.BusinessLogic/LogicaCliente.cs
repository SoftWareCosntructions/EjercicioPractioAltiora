using Altiora.Models;
using Altiora.Models.Data;
using Altiora.Models.Respuestas;
using Altiora.Models.Servicios;
using Mapster;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Altiora.BusinessLogic
{
    public class LogicaCliente : IServicioCliente
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        public LogicaCliente(IUnidadDeTrabajo unidadDeTrabajo)
        {
            this._unidadDeTrabajo = unidadDeTrabajo;
        }
        public async Task ActualizarCliente(Cliente clienteAActualizar, Cliente Cliente)
        {
            _unidadDeTrabajo.Clientes.Actualizar(clienteAActualizar);
            await _unidadDeTrabajo.CommitAsync();
        }

        public async Task<Cliente> CrearCliente(Cliente nuevoCliente)
        {
            await _unidadDeTrabajo.Clientes.InsertarAsync(nuevoCliente);
            await _unidadDeTrabajo.CommitAsync();
            return nuevoCliente;
        }

        public async Task EliminarCliente(int Id)
        {
            Cliente cliente = await _unidadDeTrabajo.Clientes.ObtenerClientePorId(Id);
            _unidadDeTrabajo.Clientes.Eliminar(cliente);
            await _unidadDeTrabajo.CommitAsync();
        }

        public async Task<RespuestaCliente> ObtenerClientePorId(int id)
        {
            Cliente cliente  = await _unidadDeTrabajo.Clientes.ObtenerClientePorId(id);
            return cliente.Adapt<RespuestaCliente>();
        }

        public async Task<IEnumerable<RespuestaCliente>> ObtenerTodos()
        {
            IEnumerable<Cliente> clientes = await _unidadDeTrabajo.Clientes.ObtenerTodos();
            return clientes.Adapt<IEnumerable<RespuestaCliente>>();
        }
    }
}
