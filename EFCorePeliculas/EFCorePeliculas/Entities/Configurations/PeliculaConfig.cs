using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entities.Configurations
{
    public class PeliculaConfig : IEntityTypeConfiguration<Pelicula>
    {
        public void Configure(EntityTypeBuilder<Pelicula> builder)
        {
            builder.Property(prop => prop.Name).HasMaxLength(150).IsRequired();
             builder.Property(prop => prop.PosterURL).HasMaxLength(500).IsUnicode(false);

            //builder.HasMany(p => p.Generos)
            //    .WithMany(g => g.Peliculas);
            
            //puedo cambiar el nombre
                //.UsingEntity(j=>j.ToTable("GenerosPeliculas"));
        }
    }
}
