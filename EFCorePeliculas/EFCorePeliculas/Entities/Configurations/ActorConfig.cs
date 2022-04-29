using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entities.Configurations
{
    public class ActorConfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(prop => prop.Name).HasMaxLength(150).IsRequired();

            builder.Property(x => x.Name).HasField("_Name");

            builder.OwnsOne(a=>a.DireccionHogar, dir=> {//puedo modificar las propiedades de direccion 
                dir.Property(d => d.calle).HasColumnName("calle");
                dir.Property(d => d.provincia).HasColumnName("provincia");
                dir.Property(d => d.pais).HasColumnName("pais");

            });
        }
    }
}
