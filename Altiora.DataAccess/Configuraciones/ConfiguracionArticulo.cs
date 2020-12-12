using Altiora.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Altiora.DataAccess.Configuraciones
{
    public class ConfiguracionArticulo : IEntityTypeConfiguration<Articulo>
    {
        public void Configure(EntityTypeBuilder<Articulo> builder)
        {
            builder
                .HasKey(m => m.IdArticulo);

            builder
                .Property(m => m.IdArticulo)
                .UseIdentityColumn();

            builder
                .ToTable("alti_tab_articulos");
        }
    }
}
