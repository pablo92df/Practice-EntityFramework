using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entities.Configurations
{
    public class SalaCineConfig : IEntityTypeConfiguration<SalaDeCine>
    {
        public void Configure(EntityTypeBuilder<SalaDeCine> builder)
        {
            builder.Property(prop => prop.Precio).HasPrecision(precision: 9, scale: 2);

            builder.Property(prop => prop.TipoSalaDeCine)
                .HasDefaultValue(TipoSalaDeCine.DosDimensiones)
                .HasConversion<string>();
            //el hasconversion combierto el valor del enum en string, esto lo hace entityframework
        }
    }
}
