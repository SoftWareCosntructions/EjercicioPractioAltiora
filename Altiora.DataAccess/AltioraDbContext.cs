using Altiora.DataAccess.Configuraciones;
using Altiora.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altiora.DataAccess
{
    public class AltioraDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<DetalleOrden> DetallesOrden { get; set; }
        public DbSet<Articulo> Articulos { get; set; }

        public AltioraDbContext(DbContextOptions<AltioraDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new ConfiguracionCliente());

            builder
                .ApplyConfiguration(new ConfiguracionOrden());

            builder
                .ApplyConfiguration(new ConfiguracionDetalleOrden());

            builder
                .ApplyConfiguration(new ConfiguracionArticulo());
        }
    }
}
