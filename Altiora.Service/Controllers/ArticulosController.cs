using Altiora.Models.Data;
using Altiora.Models.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Altiora.Service.Controllers
{
    /// <summary>
    /// Controlador Artículos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private readonly IServicioArticulo _servicioArticulo;
        private readonly ILogger<ClientesController> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="servicioArticulo">Inyección del servicio Artículo</param>
        /// <param name="logger">Inyección del logger</param>
        public ArticulosController(IServicioArticulo servicioArticulo, ILogger<ClientesController> logger)
        {
            this._servicioArticulo = servicioArticulo;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los artículos registrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> ObtenerArticulos()
        {
            var articulos = await _servicioArticulo.ObtenerTodos();
            return Ok(articulos);
        }

        /// <summary>
        /// Obtiene el artículo por Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public async Task<ActionResult<Cliente>> ObtenerCliente(int Id)
        {
            var articulo = await _servicioArticulo.ObtenerArticuloPorId(Id);
            return Ok(articulo);
        }
    }
}
