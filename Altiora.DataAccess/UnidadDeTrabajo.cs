using Altiora.DataAccess.Repositorios;
using Altiora.Models;
using Altiora.Models.Repositorios;
using System.Threading.Tasks;

namespace Altiora.DataAccess
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        private readonly AltioraDbContext _context;
        private RepositorioCliente _repositorioCliente;
        private RepositorioOrden _repositorioOrden;
        private RepositorioArticulo _repositorioArticulo;

        public UnidadDeTrabajo(AltioraDbContext context)
        {
            this._context = context;
        }
        public IRepositorioCliente Clientes => _repositorioCliente = _repositorioCliente ?? new RepositorioCliente(_context);

        public IRepositorioOrden Ordenes => _repositorioOrden = _repositorioOrden ?? new RepositorioOrden(_context);

        public IRepositorioArticulo Articulos => _repositorioArticulo = _repositorioArticulo ?? new RepositorioArticulo(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
