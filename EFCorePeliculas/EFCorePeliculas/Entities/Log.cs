using System.ComponentModel.DataAnnotations.Schema;

namespace EFCorePeliculas.Entities
{
    public class Log
    {
        //esto es para que no se genere automaticamente
        //el GUID que genera la base de datos es secuencial es mejor dejar que la DB se encargue 
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public string Mensaje { get; set; }
    }
}
