using Altiora.Models.Data;
using Altiora.Models.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Altiora.Service.Controllers
{
    /// <summary>
    /// Controlador Clientes
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IServicioCliente _servicioCliente;
        private readonly ILogger<ClientesController> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="servicioCliente">Inyeccion de dependencia IServicioCliente</param>
        /// <param name="logger">Inyeccion de dependencia de ILogger</param>
        public ClientesController(IServicioCliente servicioCliente, ILogger<ClientesController> logger)
        {
            this._servicioCliente = servicioCliente;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los clientes registrados
        /// </summary>
        /// <returns>Todos los registros de clientes</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> ObtenerClientes()
        {
            var clientes = await _servicioCliente.ObtenerTodos();
            return Ok(clientes);
        }

        /// <summary>
        /// Obtiene el cliente por Id
        /// </summary>
        /// <param name="Id">Id Cliente</param>
        /// <returns>Resultado de la consulta</returns>
        [HttpGet("{Id}")]
        public async Task<ActionResult<Cliente>> ObtenerCliente(int Id)
        {
            var cliente = await _servicioCliente.ObtenerClientePorId(Id);
            return Ok(cliente);
        }

        /// <summary>
        /// Actualiza la orden
        /// </summary>
        /// <param name="nuevoCliente">Datos para la actualización</param>
        /// <returns>resultados</returns>
        [HttpPut]
        public async Task<ActionResult> ActualizarCliente(Cliente nuevoCliente)
        {
            await _servicioCliente.ActualizarCliente(nuevoCliente, nuevoCliente);
            return Ok();
        }

        /// <summary>
        /// Inserta Cliente
        /// </summary>
        /// <param name="Cliente">Datos para nuevo registro</param>
        /// <returns>resultado</returns>
        [HttpPost]
        public async Task<ActionResult> InsertarCliente(Cliente Cliente)
        {
            await _servicioCliente.CrearCliente(Cliente);
            return Ok();
        }

        /// <summary>
        /// Eliminar Cliente
        /// </summary>
        /// <param name="Id">IdCliente a eliminar</param>
        /// <returns>resultado</returns>
        [HttpDelete]
        public async Task<ActionResult> EliminarCliente(int Id)
        {
            await _servicioCliente.EliminarCliente(Id);
            return Ok();
        }
    }
}
