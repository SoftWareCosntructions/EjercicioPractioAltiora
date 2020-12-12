using Altiora.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Altiora.DataAccess.Configuraciones
{
    public class ConfiguracionOrden : IEntityTypeConfiguration<Orden>
    {
        public void Configure(EntityTypeBuilder<Orden> builder)
        {
            builder
                .HasKey(m => m.IdOrden);

            builder
                .Property(m => m.IdOrden)
                .UseIdentityColumn();

            builder
                .HasOne(m => m.Cliente)
                .WithMany(a => a.Ordenes)
                .HasForeignKey(m => m.IdCliente);

            builder
                .ToTable("alti_tab_ordenes");
        }
    }
}
