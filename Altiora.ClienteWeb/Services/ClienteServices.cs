using Altiora.ClienteWeb.Modelos;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Altiora.ClienteWeb.Services
{
    public class ClienteServices: IClienteServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _remoteServiceBaseUrl;
        public ClienteServices(HttpClient httpClient, IConfiguration Configuration)
        {
            _httpClient = httpClient;
        }

        public async Task DeleteClienteAsync(int Id)
        {
            await _httpClient.DeleteAsync(_remoteServiceBaseUrl + Id);
        }

        public async Task<Cliente> GetClienteAsync(int Id)
        {
            var responseString = await _httpClient.GetAsync(_remoteServiceBaseUrl);

            Cliente cliente = JsonConvert.DeserializeObject<Cliente>(responseString.ToString());
            return cliente;
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {

            var responseString = await _httpClient.GetAsync(_remoteServiceBaseUrl);

            IEnumerable<Cliente> catalog = JsonConvert.DeserializeObject<IEnumerable<Cliente>>(responseString.ToString());
            return catalog;
        }

        public async Task PostClienteAsync(Cliente cliente)
        {
            try
            {
                StringContent clienteJson = new StringContent(System.Text.Json.JsonSerializer.Serialize(cliente), Encoding.UTF8, "application/json");
                await _httpClient.PostAsync(_remoteServiceBaseUrl, clienteJson);

            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task PutClienteAsync(Cliente cliente)
        {
            StringContent clienteJson = new StringContent(System.Text.Json.JsonSerializer.Serialize(cliente), Encoding.UTF8, "application/json");
            await _httpClient.PutAsync(_remoteServiceBaseUrl, clienteJson);
        }
    }
}
