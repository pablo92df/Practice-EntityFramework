using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [Precision(18,2)]
        public decimal Precio { get; set; }

    }
}
