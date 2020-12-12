using Altiora.Models.Data;
using Altiora.Models.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Altiora.DataAccess.Repositorios
{
    public class RepositorioCliente : Repositorio<Cliente>, IRepositorioCliente
    {
        public RepositorioCliente(AltioraDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Cliente>> ObtenerTodos()
        {
            return await AltioraDbContext.Clientes
                .Include(m => m.Ordenes)
                .ThenInclude(m => m.DetallesOrden)
                .ThenInclude(m => m.Articulo)
                .ToListAsync();
        }

        public async Task<Cliente> ObtenerClientePorId(int id)
        {
            return await AltioraDbContext.Clientes
                .Include(m => m.Ordenes)
                .ThenInclude(m => m.DetallesOrden)
                .ThenInclude(m => m.Articulo)
                .SingleOrDefaultAsync(m => m.IdCliente == id);
        }

        public void InsertarCliente(Cliente entidad)
        {
            AltioraDbContext.Update(entidad);
        }

        public void ActualizarCliente(Cliente entidad)
        {
            AltioraDbContext.Add(entidad);
        }

        public void EliminarCliente(int IdCliente)
        {
            Cliente clienteEliminar = AltioraDbContext.Clientes.FirstOrDefault(c => c.IdCliente == IdCliente);
            AltioraDbContext.Remove(clienteEliminar);
        }

        private AltioraDbContext AltioraDbContext
        {
            get { return Context as AltioraDbContext; }
        }
    }
}
