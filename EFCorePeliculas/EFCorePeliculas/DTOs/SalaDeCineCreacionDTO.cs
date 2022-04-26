using EFCorePeliculas.Entities;

namespace EFCorePeliculas.DTOs
{
    public class SalaDeCineCreacionDTO
    {
        public decimal Precio { get; set; }
        public TipoSalaDeCine  TipoSalaDeCine { get; set; }
    }
}
