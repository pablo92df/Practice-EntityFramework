using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCorePeliculas.Entities.Conversiones
{
    public class MonedaASimbolo : ValueConverter<Moneda, string>
    {
        public MonedaASimbolo() : 
            base(
                valor => MapeoMonedaString(valor),
                valor => MapeoStringMoneda(valor)
                )
        {

        }

        private static string MapeoMonedaString(Moneda valor) 
        {
            return valor switch
            {
                Moneda.Peso => "$$",
                Moneda.Dolar => "$",
                _ => ""//valor por defecto
            };
        }

        private static Moneda MapeoStringMoneda(string valor) 
        {
            return valor switch
            {
                "$$" => Moneda.Peso,
                "$" => Moneda.Dolar,
                _ => Moneda.Desconocida//valor por defecto
            };
        }
    }
}
