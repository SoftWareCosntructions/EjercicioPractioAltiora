using Altiora.ClienteWeb.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Altiora.ClienteWeb.Services
{
    public interface IClienteServices
    {
        Task<IEnumerable<Cliente>> GetClientesAsync();
        Task<Cliente> GetClienteAsync(int Id);
        Task PostClienteAsync(Cliente cliente);
        Task PutClienteAsync(Cliente cliente);
        Task DeleteClienteAsync(int Id);
    }
}
