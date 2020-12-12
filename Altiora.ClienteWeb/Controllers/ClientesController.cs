using Altiora.ClienteWeb.Modelos;
using Altiora.ClienteWeb.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Altiora.ClienteWeb.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClientes _client;
        private readonly HttpClient _httpClient;
        private IClienteServices _clienteSvc;
        public ClientesController(IClientes cliente, IHttpClientFactory client, IClienteServices clienteSvc)
        {
            _client = cliente;
            _httpClient = client.CreateClient("AltioraService");
            _clienteSvc = clienteSvc;
        }

        [HttpGet]
        [Route("api/clientes")]
        public async Task<IEnumerable<Cliente>> ConsultarClientes()
        {
            var res = await _client.GetClientesAsync();
            return res;
        }

        [HttpGet]
        [Route("api/clientes/{Id}")]
        public async Task<Cliente> ConsultarCliente(int Id)
        {
            return await _client.GetClienteAsync(Id);
        }

        [HttpPost]
        [Route("api/clientes/")]
        public async Task AgregarCliente([FromBody]Cliente cliente)
        {
            var clienteJson = new StringContent(
                JsonSerializer.Serialize(cliente), Encoding.UTF8,
                "application/json");

            using var httpResponse =
                await _httpClient.PostAsync("/api/Clientes/", clienteJson);

            httpResponse.EnsureSuccessStatusCode();
        }

        [HttpPut]
        [Route("api/clientes/")]
        public async Task ActualizarCliente([FromBody]Cliente cliente)
        {
            var clienteJson = new StringContent(
                JsonSerializer.Serialize(cliente), Encoding.UTF8,
                "application/json");

            using var httpResponse =
                await _httpClient.PutAsync("/api/Clientes/", clienteJson);

            httpResponse.EnsureSuccessStatusCode();
        }

        [HttpDelete]
        [Route("api/clientes/{Id}")]
        public async Task EliminarCliente(int Id)
        {
            await _client.DeleteClienteAsync(Id);
        }
    }
}
