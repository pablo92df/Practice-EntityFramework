using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entities.Configurations
{
    public class PeliculaActorConfig : IEntityTypeConfiguration<PeliculaActor>
    {
        public void Configure(EntityTypeBuilder<PeliculaActor> builder)
        {
            //configurarion muchos a muchos con clase intermedia personalizada

            builder.HasKey(prop => new { prop.PeliculaID, prop.ActorId });
            //configuro las relaciones uno a muchos de ambos y esto crea una relacion muchos a muchos
            //si uso la configuracion por convencion no haria falta hacer todo esto
            //builder.HasOne(p => p.Actor)
            //    .WithMany(a => a.PeliculasActores)
            //    .HasForeignKey(p => p.ActorId);

            //builder.HasOne(p => p.Pelicula)
            //    .WithMany(pa => pa.PeliculasActores)
            //    .HasForeignKey(p => p.ActorId);

            builder.Property(prop => prop.Personaje).HasMaxLength(150);

        }
    }
}
