using Altiora.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Altiora.DataAccess.Configuraciones
{
    public class ConfiguracionCliente : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder
                .HasKey(m => m.IdCliente);

            builder
                .Property(m => m.IdCliente)
                .UseIdentityColumn();

            builder
                .ToTable("alti_tab_clientes");
        }
    }
}
