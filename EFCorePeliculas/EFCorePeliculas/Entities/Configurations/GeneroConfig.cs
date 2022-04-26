using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entities.Configurations
{
    //esta clase permite poner las configurarion del api fluente por clase, asi se tiene todo mas ordenado
    public class GeneroConfig : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder) 
        {
            // builder.Entity<Genero>().Property(prop => prop.Nombre).HasMaxLength(150).IsRequired();
            builder.ToTable(name: "TablaGeneros", schema: "Peliculas");//sirve para cambiar el nombre de la tabla

            builder.HasQueryFilter(g => !g.EstaBorrado);
            //le agrego un filtro
            builder.HasIndex(g => g.Nombre).IsUnique().HasFilter("EstaBorrado = 'false'");

        }
    }
}
