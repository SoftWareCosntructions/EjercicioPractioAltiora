using Altiora.Models.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altiora.Models
{
    public interface IUnidadDeTrabajo : IDisposable
    {
        IRepositorioCliente Clientes { get; }
        IRepositorioOrden Ordenes { get; }
        IRepositorioArticulo Articulos { get; }
        Task<int> CommitAsync();
    }
}
