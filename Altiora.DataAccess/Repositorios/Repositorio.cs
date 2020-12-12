using Altiora.Models.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Altiora.DataAccess.Repositorios
{
    public class Repositorio<TEntity> : IRepositorio<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repositorio(DbContext context)
        {
            this.Context = context;
        }
        public async Task InsertarAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
        }

        public void Actualizar(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
        }

        public async Task InsertarRangoAsync(IEnumerable<TEntity> entities)
        {
            await Context.Set<TEntity>().AddRangeAsync(entities);
        }

        public IEnumerable<TEntity> Encontrar(Expression<Func<TEntity, bool>> predicado)
        {
            return Context.Set<TEntity>().Where(predicado);
        }

        public async Task<IEnumerable<TEntity>> ObtenerTodosAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public ValueTask<TEntity> ObtenerPorIdAsync(int id)
        {
            return Context.Set<TEntity>().FindAsync(id);
        }

        public void Eliminar(TEntity entidad)
        {
            Context.Set<TEntity>().Remove(entidad);
        }

        public void EliminarRango(IEnumerable<TEntity> enditades)
        {
            Context.Set<TEntity>().RemoveRange(enditades);
        }

        public Task<TEntity> SoloUnaOPorDefecto(Expression<Func<TEntity, bool>> predicado)
        {
            return Context.Set<TEntity>().SingleOrDefaultAsync(predicado);
        }
    }
}
