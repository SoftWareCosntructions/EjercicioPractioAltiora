using Altiora.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Altiora.DataAccess.Configuraciones
{
    public class ConfiguracionDetalleOrden : IEntityTypeConfiguration<DetalleOrden>
    {
        public void Configure(EntityTypeBuilder<DetalleOrden> builder)
        {
            builder
                .HasKey(m => m.IdDetalleOrden);

            builder
                .Property(m => m.IdDetalleOrden)
                .UseIdentityColumn();

            builder
                .HasOne(m => m.Orden)
                .WithMany(a => a.DetallesOrden)
                .HasForeignKey(m => m.IdOrden);

            builder
                .HasOne(m => m.Articulo)
                .WithMany(a => a.DetallesOrden)
                .HasForeignKey(m => m.IdArticulo);

            builder
                .ToTable("alti_tab_detalles_orden");
        }
    }
}
