namespace EFCorePeliculas.Entities
{
    public class PeliculaActor
    {
        public int PeliculaID { get; set; }
        public int ActorId { get; set; }
        public string Personaje { get; set; }
        public int Orden { get; set; }
        public  Pelicula Pelicula { get; set; }
        public  Actor Actor { get; set; }
    }
}
