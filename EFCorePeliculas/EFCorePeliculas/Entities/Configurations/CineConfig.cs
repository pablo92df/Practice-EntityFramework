using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entities.Configurations
{
    public class CineConfig :IEntityTypeConfiguration<Cine>
    {
        public void Configure(EntityTypeBuilder<Cine> builder)
        {
            builder.Property(prop => prop.Name).HasMaxLength(150).IsRequired();

            //configurar relacion uno a uno usando API fluente
            builder.HasOne(c => c.CineOferta)
                .WithOne()
                .HasForeignKey<CineOferta>(co=>co.CineId);
            //configurar uno a muchos, en este caso el ondelete esw para que no se pueda borrar cines si tienen salas de cine
            builder.HasMany(c => c.SalasDeCines).WithOne(s => s.Cine).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.CineDetalle).WithOne(cd => cd.Cine).HasForeignKey<CineDetalle>(cd => cd.Id);

            builder.OwnsOne(c => c.Direccion, dir =>
              {//puedo modificar las propiedades de direccion 
                dir.Property(d => d.calle).HasColumnName("calle");
                  dir.Property(d => d.provincia).HasColumnName("provincia");
                  dir.Property(d => d.pais).HasColumnName("pais");

              });

        }
    }
}
