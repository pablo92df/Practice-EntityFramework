using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entities.Configurations
{
    public class CineDetalleConfig : IEntityTypeConfiguration<CineDetalle>
    {
        public void Configure(EntityTypeBuilder<CineDetalle> builder)
        {
            //para poder crear la division de tablas, esto une las entidades en la dase de datos
            builder.ToTable("Cines");
        }
    }
}
