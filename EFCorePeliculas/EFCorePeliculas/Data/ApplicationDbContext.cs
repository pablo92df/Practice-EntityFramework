using EFCorePeliculas.Entities;
using EFCorePeliculas.Entities.Seeding;
using EFCorePeliculas.Entities.SinLlaves;
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
            SeedingPersonaMensaje.Seed(modelBuilder);

            //escribo la query de donde saco los datos para poner en CineSinUbicacion 
            modelBuilder.Entity<CineSinUbicacion>().ToSqlQuery("Select Id, Name From Cines").ToView(null);


            modelBuilder.Entity<PeliculaConConteos>().HasNoKey().ToView("PeliculasConConteos");

            //con esto puedo afectar a todas las entidas ya que las recorro ahora aplico a cualquier entidad 
            foreach (var tipoEntidad in modelBuilder.Model.GetEntityTypes()) 
            {
                foreach (var propiedad in tipoEntidad.GetProperties())
                {//Clrtype es para ver que tipo de dato es la propiedad
                    if (propiedad.ClrType == typeof(string) && propiedad.Name.Contains("URL", StringComparison.CurrentCultureIgnoreCase))
                    {
                        //en este caso configuro todas las propiedas que tengan URL en su nombre 
                        propiedad.SetIsUnicode(false);
                        propiedad.SetMaxLength(500);
                    }
                }
            }
            //aca configuro para que cada clase que hereda de producto cree una tabla en la DB
            modelBuilder.Entity<Merchandising>().ToTable("Merchandising");
            modelBuilder.Entity<PeliculaAlquilable>().ToTable("PeliculaAlquilable");

            var pelicula1 = new PeliculaAlquilable()
            {
                Id = 1,
                Nombre = "Spider-Man",
                PeliculaId = 1,
                Precio = 5.99m
            };
            var mercha1 = new Merchandising()
            {
                Id = 2,
                DisponibleEnInventario = true,
                EsRopa = true,
                Nombre = "Shirt One Piece",
                Peso = 1,
                Volumen = 1,
                Precio = 11
            };

            modelBuilder.Entity<Merchandising>().HasData(mercha1);
            modelBuilder.Entity<PeliculaAlquilable>().HasData(pelicula1);

            //este sirve para asignar una PK, por defecto si no pongo nada solo se reconoce como PK si se llama Id o claseID
            //si uso otro nombre tengo que usar [Key] o modifico aca
            // modelBuilder.Entity<Genero>().HasKey(prop => prop.Identificador);
            //limita el string en la base de datos
            // modelBuilder.Entity<Genero>().Property(prop => prop.Nombre).HasMaxLength(150).IsRequired();
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
        public DbSet<CineSinUbicacion> CineSinUbicacions { get; set; }
        public DbSet<Log> Logs  { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Mensaje> Mensajes { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Producto> Productos { get; set; }
    }
}
