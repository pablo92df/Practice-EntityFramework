namespace EFCorePeliculas.Entities
{
    public abstract class Pago
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public TipoPago TipoPago { get; set; }
    }
}
