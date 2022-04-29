using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCorePeliculas.Entities
{
    //[NotMapped]//ignora la clase a la hora de la migracion
    [Owned]//esto es que otra entidad se va a adueñiar de esta entidad
    public class Direccion
    {
        public string calle { get; set; }
        public string provincia { get; set; }
        [Required]
        public string pais { get; set; }
    }
}
