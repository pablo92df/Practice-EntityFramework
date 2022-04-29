using System.ComponentModel.DataAnnotations;

namespace EFCorePeliculas.Entities
{
    public class CineDetalle
    {
        //esto es para un division de tablas
        //en la base de datos la entidad cine contienen todos estos campos, pero en las entidades esta dividido 
        //para esto es obligatorio que haya un campo required
        public int Id { get; set; }
        [Required]
        public string Historia { get; set; }
        public string Valores { get; set; }
        public string Misiones { get; set; }
        public string CodigoDeEtica { get; set; }
        public Cine Cine { get; set; }
    }
}
