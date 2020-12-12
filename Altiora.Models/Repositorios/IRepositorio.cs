using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Altiora.Models.Repositorios
{
    /// <summary>
    /// Interfas para repositorios
    /// </summary>
    public interface IRepositorio<TEntity> where TEntity : class
    {
        ValueTask<TEntity> ObtenerPorIdAsync(int id);
        Task<IEnumerable<TEntity>> ObtenerTodosAsync();
        IEnumerable<TEntity> Encontrar(Expression<Func<TEntity, bool>> predicado);
        Task<TEntity> SoloUnaOPorDefecto(Expression<Func<TEntity, bool>> predicado);
        Task InsertarAsync(TEntity entidad);
        void Actualizar(TEntity entidad);
        Task InsertarRangoAsync(IEnumerable<TEntity> entidades);
        void Eliminar(TEntity entidad);
        void EliminarRango(IEnumerable<TEntity> entidades);
    }
}
