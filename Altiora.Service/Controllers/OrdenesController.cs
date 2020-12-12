using Altiora.Models.Data;
using Altiora.Models.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Altiora.Service.Controllers
{
    /// <summary>
    /// Controlador Ordenes
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesController : ControllerBase
    {
        private readonly IServicioOrden _servicioOrden;
        private readonly ILogger<OrdenesController> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="servicioOrden">Servicio de entidad Orden</param>
        /// <param name="logger">Logger</param>
        public OrdenesController(IServicioOrden servicioOrden, ILogger<OrdenesController> logger)
        {
            this._servicioOrden = servicioOrden;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todas las ordenes registrados
        /// </summary>
        /// <returns>Registros resultado de la consulta</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> ObtenerOrdenes()
        {
            var ordenes = await _servicioOrden.ObtenerTodos();
            return Ok(ordenes);
        }

        /// <summary>
        /// Obtiene la orden por Id
        /// </summary>
        /// <param name="Id">IdCliente</param>
        /// <returns>Registro resultado de la consulta</returns>
        [HttpGet("{Id}")]
        public async Task<ActionResult<Cliente>> ObtenerOrden(int Id)
        {
            var cliente = await _servicioOrden.ObtenerOrdenPorId(Id);
            return Ok(cliente);
        }

        /// <summary>
        /// Actualiza la orden
        /// </summary>
        /// <param name="nuevaOrden">Datos para la actualización</param>
        /// <returns>resultados</returns>
        [HttpPut]
        public async Task<ActionResult> ActualizarOrdenAsync(Orden nuevaOrden)
        {
            await _servicioOrden.ActualizarOrden(nuevaOrden, nuevaOrden);
            return Ok();
        }

        /// <summary>
        /// Inserta orden
        /// </summary>
        /// <param name="orden">Datos para nuevo registro</param>
        /// <returns>resultado</returns>
        [HttpPost]
        public async Task<ActionResult> InsertarOrdenAsync(Orden orden)
        {
            await _servicioOrden.CrearOrden(orden);
            return Ok();
        }

        /// <summary>
        /// Eliminar orden
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>resultado</returns>
        [HttpDelete]
        public async Task<ActionResult> EliminarOrdenAsync(int Id)
        {
            await _servicioOrden.EliminarOrden(Id);
            return Ok();
        }
    }
}
