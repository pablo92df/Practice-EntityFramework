using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Entities.Seeding
{
    public static class SeedingPersonaMensaje
    {
        public static void Seed(ModelBuilder modelBuilder)
        { 
        
            var felipe = new Persona() { Id=1, Name = "Felipe" };
            var claudia = new Persona() { Id = 2, Name = "Claudia" };

            var mensaje1 = new Mensaje() { Id = 1, Contenido = "Hola, Claudia!", EmisorID = felipe.Id, ReceptorID = claudia.Id };
            var mensaje2 = new Mensaje() { Id = 2, Contenido = "Hola, Felipe, ¿Cómo te va?", EmisorID = claudia.Id, ReceptorID = felipe.Id };
            var mensaje3 = new Mensaje() { Id = 3, Contenido = "Todo bien, ¿Y tú?", EmisorID = felipe.Id, ReceptorID = claudia.Id };
            var mensaje4 = new Mensaje() { Id = 4, Contenido = "Muy bien :)", EmisorID = claudia.Id, ReceptorID = felipe.Id };

            modelBuilder.Entity<Persona>().HasData(felipe, claudia);
            modelBuilder.Entity<Mensaje>().HasData(mensaje1, mensaje2, mensaje3, mensaje4);
        }
    }
}
