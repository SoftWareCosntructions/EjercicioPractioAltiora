using Altiora.Models.Data;
using Altiora.Models.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altiora.DataAccess.Repositorios
{
    public class RepositorioOrden : Repositorio<Orden>, IRepositorioOrden
    {
        public RepositorioOrden(AltioraDbContext context)
            : base(context)
        { }

        public async Task ActualizarOrden(Orden entidad)
        {
            AltioraDbContext.Update(entidad);
            await AltioraDbContext.SaveChangesAsync();
        }

        public void EliminarOrden(Orden entidad)
        {
            AltioraDbContext.Remove(entidad);
            AltioraDbContext.SaveChanges();
        }

        public async Task InsertarOrden(Orden entidad)
        {
            AltioraDbContext.Add(entidad);
            await AltioraDbContext.SaveChangesAsync();
        }

        public async Task<Orden> ObtenerOrdenPorId(int id)
        {
            return await AltioraDbContext.Ordenes
                .Include(m => m.Cliente)
                .Include(m => m.DetallesOrden)
                .ThenInclude(m => m.Articulo)
                .SingleOrDefaultAsync(m => m.IdOrden == id);
        }

        public async Task<IEnumerable<Orden>> ObtenerTodos()
        {
            return await AltioraDbContext.Ordenes
                .Include(m => m.Cliente)
                .Include(m => m.DetallesOrden)
                .ThenInclude(m => m.Articulo)
                .ToListAsync();
        }

        private AltioraDbContext AltioraDbContext
        {
            get { return Context as AltioraDbContext; }
        }
    }
}
