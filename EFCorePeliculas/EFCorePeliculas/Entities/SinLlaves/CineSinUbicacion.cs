using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Entities.SinLlaves
{
    [Keyless]//para que la entidad en la base de datos no tenga una KEY
    public class CineSinUbicacion
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
