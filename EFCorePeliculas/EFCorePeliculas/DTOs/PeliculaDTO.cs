namespace EFCorePeliculas.DTOs
{
    public class PeliculaDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //al ser Icollection podria ser cualquier cosa y tampoco asegura el orden de las cosas
        public ICollection<GeneroDTO> Generos { get; set; } = new List<GeneroDTO>();
        public ICollection<CineDTO> Cines { get; set; }
        public ICollection<ActorDTO> Actores { get; set; }
    }
}
