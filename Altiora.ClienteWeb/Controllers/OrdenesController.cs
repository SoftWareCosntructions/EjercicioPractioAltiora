using Altiora.ClienteWeb.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Altiora.ClienteWeb.Controllers
{
    public class OrdenesController : Controller
    {
        private readonly IOrdenes _client;

        public OrdenesController(IOrdenes client)
        {
            _client = client;
        }

        [HttpGet]
        [Route("api/ordenes")]
        public async Task<IEnumerable<Orden>> ConsultarOrdenes()
        {
            var res = await _client.GetOrdenesAsync();
            return res;
        }

        [HttpGet]
        [Route("api/ordenes/{Id}")]
        public async Task<Orden> ConsultarOrden(int Id)
        {
            return await _client.GetOrdenesAsync(Id);
        }

        [HttpPost]
        [Route("api/ordenes")]
        public async Task<Orden> InsertarOrden(Orden orden)
        {
            return await _client.PostOrdenesAsync(orden);
        }

        [HttpPut]
        [Route("api/ordenes/{Id}")]
        public async Task ActualizarOrden(int Id, Orden orden)
        {
            await _client.PutOrdenesAsync(orden);
        }

        [HttpDelete]
        [Route("api/ordenes")]
        public async Task EliminarOrden(Orden orden)
        {
            await _client.DeleteOrdenesAsync(orden);
        }
    }
}
