using System.ComponentModel.DataAnnotations.Schema;

namespace EFCorePeliculas.Entities
{
    public class Persona
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [InverseProperty("Emisor")]
        public List<Mensaje> MensajesEnviados { get; set; }
        [InverseProperty("Receptor")]

        public List<Mensaje> MensajesRecibidos { get; set; }

    }
}
