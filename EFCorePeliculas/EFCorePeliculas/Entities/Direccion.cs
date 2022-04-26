using System.ComponentModel.DataAnnotations.Schema;

namespace EFCorePeliculas.Entities
{
    [NotMapped]//ignora la clase a la hora de la migracion
    public class Direccion
    {
        public string calle { get; set; }
        public string provincia { get; set; }
        public string pais { get; set; }
    }
}
