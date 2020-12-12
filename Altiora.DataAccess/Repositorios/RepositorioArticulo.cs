using Altiora.Models.Data;
using Altiora.Models.Repositorios;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Altiora.DataAccess.Repositorios
{
    public class RepositorioArticulo : Repositorio<Articulo>, IRepositorioArticulo
    {
        public RepositorioArticulo(AltioraDbContext context)
            : base(context)
        { }

        public async Task<Articulo> ObtenerArticuloPorId(int id)
        {
            return await AltioraDbContext.Articulos
                .SingleOrDefaultAsync(m => m.IdArticulo == id);
        }

        public async Task<IEnumerable<Articulo>> ObtenerTodos()
        {
            return await AltioraDbContext.Articulos
                .ToListAsync();
        }

        private AltioraDbContext AltioraDbContext
        {
            get { return Context as AltioraDbContext; }
        }
    }
}
