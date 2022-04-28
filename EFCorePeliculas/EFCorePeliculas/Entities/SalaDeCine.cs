using System.ComponentModel.DataAnnotations.Schema;

namespace EFCorePeliculas.Entities
{
    public class SalaDeCine
    {
        public int Id { get; set; }
        public TipoSalaDeCine TipoSalaDeCine { get; set; }
        public decimal Precio { get; set; }
        public int CineId { get; set; }
        //con esto indico cual es la llave foranea de la relacion,
        //mas que nada lo uso si no sigo las convenciones como poner CineId(si sgue la convencion)
        //es para cuando pongo otro nombre ejemplo ElCine
        [ForeignKey(nameof(CineId))]
        public  Cine Cine { get; set; }

        public  HashSet<Pelicula> Peliculas { get; set; }
        public Moneda Moneda { get; set; }
    }
}
