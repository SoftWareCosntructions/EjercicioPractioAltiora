using Altiora.ClienteWeb.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Altiora.ClienteWeb.Controllers
{
    public class ArticulosController : Controller
    {
        private readonly IArticulos _client;

        public ArticulosController(IArticulos client)
        {
            _client = client;
        }

        [HttpGet]
        [Route("api/articulos")]
        public async Task<IEnumerable<Articulo>> ConsultarArticulos()
        {
            var res = await _client.GetArticulosAsync();
            return res;
        }

        [HttpGet]
        [Route("api/articulos/{Id}")]
        public async Task<Articulo> ConsultarArticulo(int Id)
        {
            return await _client.GetArticulosAsync(Id);
        }
    }
}
