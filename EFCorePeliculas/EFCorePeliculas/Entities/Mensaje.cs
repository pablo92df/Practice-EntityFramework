namespace EFCorePeliculas.Entities
{
    public class Mensaje
    {
        public int Id { get; set; }
        public string Contenido { get; set; }
        public int EmisorID { get; set; }
        public Persona Emisor { get; set; }
        public int ReceptorID { get; set; }
        public Persona  Receptor { get; set; }
    }
}
