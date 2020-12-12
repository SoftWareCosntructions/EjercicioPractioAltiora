using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Altiora.ClienteWeb.Modelos
{
    public interface IClientes
    {
        [Get("/Clientes")]
        Task<IEnumerable<Cliente>> GetClientesAsync();

        [Get("/Clientes/{Id}")]
        Task<Cliente> GetClienteAsync(int Id);
        
        [Post("/Clientes/")]
        Task PostClienteAsync(Cliente cliente);

        [Put("/Clientes/")]
        Task PutClienteAsync(Cliente cliente);

        [Delete("/Clientes/")]
        Task DeleteClienteAsync(int Id);
    }

    public interface IArticulos
    {
        [Get("/Articulos")]
        Task<IEnumerable<Articulo>> GetArticulosAsync();

        [Get("/Articulos/{Id}")]
        Task<Articulo> GetArticulosAsync(int Id);
    }

    public interface IOrdenes
    {
        [Get("/Ordenes")]
        Task<IEnumerable<Orden>> GetOrdenesAsync();

        [Get("/Ordenes/{Id}")]
        Task<Orden> GetOrdenesAsync(int Id);

        [Post("/Ordenes/")]
        Task<Orden> PostOrdenesAsync(Orden orden);

        [Put("/Ordenes/")]
        Task PutOrdenesAsync(Orden orden);

        [Delete("/Ordenes/")]
        Task DeleteOrdenesAsync(Orden orden);
    }
}
