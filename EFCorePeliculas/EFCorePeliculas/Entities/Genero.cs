using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCorePeliculas.Entities
{
  //  [Table("TablaGeneros", Schema = "peliculas")]
    //con esto puedo poner el nombre a la tabla que quiera sin que sea igual al de la clase

    //creo un indice con el nombre y lo hago unico
   // [Index(nameof(Nombre), IsUnique = true)]
    public class Genero
    {
        //[Key]
      //  public int Identificador { get; set; }
        public int Id { get; set; }
       // [StringLength(150)]//stringlenght y maxlenght hacen lo mismo en los strings
        [MaxLength(150)]
       // [Column("NombreGenero")] cambio el nombre de la columna en la tabla
        public string Nombre { get; set; }
        public bool EstaBorrado { get; set; }
        //para crear relacion muchos a muchos
        public  HashSet<Pelicula> Peliculas { get; set; }
    }
}
