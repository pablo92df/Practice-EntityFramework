namespace EFCorePeliculas.Entities
{
    public class CineOferta
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal PorcentajeDescuento { get; set; }
        //lo hago nulleable para crear una relacion opcional. Si borro un cine tengo que cambiar el valor de cineId por null
        //si no fuese opcional al borrar el cine se borra la relacion
        public int? CineId { get; set; }

    }
}
