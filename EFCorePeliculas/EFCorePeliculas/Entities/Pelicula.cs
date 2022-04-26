using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Entities
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool EnCartelera { get; set; }
        public DateTime FechaEstreno { get; set; }
        [Unicode(false)]
        public string PosterURL { get; set; }

        //para crear relacion muchos a muchos
        //el HashSet no asegura que los elementos esten ordenados mejor usar listas
        public  List<Genero> Generos { get; set; }
        public  List<SalaDeCine> SalaDeCines { get; set; }

        public  List<PeliculaActor> PeliculasActores { get; set; }

    }
}
