using EFCorePeliculas.Entities;
using EFCorePeliculas.Entities.Seeding;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EFCorePeliculas.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions opctions) : base(opctions)
        {

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            //todos los campos datetime los mapea tipo date en la base de datos. Esto lo hace por defecto
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
        }
        //permite modificar cosas que las atributos como [Key] que se usan en la clase no pueden. Este es mas completo
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            //carga las configuraciones de la carpeta configurations
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            SeedingModuloConsultas.Seed(modelBuilder);

            //este sirve para asignar una PK, por defecto si no pongo nada solo se reconoce como PK si se llama Id o claseID
            //si uso otro nombre tengo que usar [Key] o modifico aca
            // modelBuilder.Entity<Genero>().HasKey(prop => prop.Identificador);
            //limita el string en la base de datos
            //// modelBuilder.Entity<Genero>().Property(prop => prop.Nombre).HasMaxLength(150).IsRequired();
            //modelBuilder.Entity<Genero>().ToTable(name: "TablaGeneros", schema: "Peliculas");//sirve para cambiar el nombre de la tabla


            // modelBuilder.Entity<Actor>().Property(prop => prop.Name).HasMaxLength(150).IsRequired();
            //modelBuilder.Entity<Actor>().Property(prop => prop.FechaNacimiento).HasColumnType("date");

            //modelBuilder.Entity<Cine>().Property(prop => prop.Name).HasMaxLength(150).IsRequired();

            // modelBuilder.Entity<Pelicula>().Property(prop => prop.Name).HasMaxLength(150).IsRequired();
            //// modelBuilder.Entity<Pelicula>().Property(prop => prop.FechaEstreno).HasColumnType("date");
            // //unicode es porque solo va texto plano por la url, si queres poner emojis por ejemplo el unicode tiene que estar activo
            // modelBuilder.Entity<Pelicula>().Property(prop => prop.PosterURL).HasMaxLength(500).IsUnicode(false);

            //modelBuilder.Entity<CineOferta>().Property(prop => prop.PorcentajeDescuento).HasPrecision(precision: 5, scale: 2);
            //  modelBuilder.Entity<CineOferta>().Property(prop => prop.FechaFin).HasColumnType("date");
            // modelBuilder.Entity<CineOferta>().Property(prop => prop.FechaInicio).HasColumnType("date");


            //modelBuilder.Entity<SalaDeCine>().Property(prop => prop.Precio).HasPrecision(precision: 9, scale: 2);
            //modelBuilder.Entity<SalaDeCine>().Property(prop => prop.TipoSalaDeCine).HasDefaultValue(TipoSalaDeCine.DosDimensiones);

            //modelBuilder.Entity<PeliculaActor>().HasKey(prop => new { prop.PeliculaID, prop.ActorId });

            //modelBuilder.Entity<PeliculaActor>().Property(prop => prop.Personaje).HasMaxLength(150);
           // modelBuilder.Ignore<Direccion>();
        }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Cine> Cines { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<CineOferta> CinesOfertas { get; set; }
        public DbSet<SalaDeCine> SalasDeCine { get; set; }
        public DbSet<PeliculaActor> PeliculasActores { get; set; }

        public DbSet<Log> Logs  { get; set; }
    }
}
