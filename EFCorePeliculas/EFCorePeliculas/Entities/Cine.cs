
using NetTopologySuite.Geometries;

namespace EFCorePeliculas.Entities
{
    public class Cine
    {
        public int Id { get; set; }
        public string Name { get; set; }
       // [Precision(precision:9, scale 2)]

        public Point Ubicacion { get; set; }

        //Propiedad de navegacion--> nos permite navegar entre entidades de una relacion.
        public CineOferta CineOferta { get; set;}
        //hashset es mas rapido que otras alternativas como Icollection, pero hashset no ordena
        //se podria usar List si quiero ordenar
        public  HashSet<SalaDeCine> SalasDeCines { get; set; }
    }
}
