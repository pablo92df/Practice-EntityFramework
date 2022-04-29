using System.ComponentModel.DataAnnotations.Schema;

namespace EFCorePeliculas.Entities
{
    public class Actor
    {
        public int Id { get; set; }
        private string _Name;

        public string Name
        { get
            {
                return _Name;
            }
            set
            {
                _Name = string.Join(' ', value.Split(' ')
                    .Select(x => x[0].ToString().ToUpper() + x.Substring(1).ToLower()).ToArray());
            }
        }
        public string Biografia { get; set; }
        //  [Column(TypeName = "Date")]
        public DateTime? FechaNacimiento { get; set; }
        public HashSet<PeliculaActor> PeliculasActores { get; set; }
        public string FotoURL {get;set;}
        [NotMapped]//ignora la propiedad en la migracion y no crea la columna en la base de datos
        public int? Edad 
        {
            get 
            {
                if (!FechaNacimiento.HasValue) 
                {
                    return null;
                }
                var fechaNaciemiento = FechaNacimiento.Value;
                var edad = DateTime.Today.Year - fechaNaciemiento.Year;

                if (new DateTime(DateTime.Today.Year, fechaNaciemiento.Month, fechaNaciemiento.Day) > DateTime.Today)
                {
                    edad--;
                }

                return edad;
            }
        }

        public Direccion DireccionHogar { get; set; }
        public Direccion BillingAddress { get; set; }

    }
}
