using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entities.Configurations
{
    public class PagoTarjetaConfig : IEntityTypeConfiguration<PagoTarjeta>
    {
        public void Configure(EntityTypeBuilder<PagoTarjeta> builder)
        {
            builder.Property(p => p.Ultimos4Difitos).HasColumnType("char(4)").IsRequired();
            var pago1 = new PagoTarjeta()
            {
                Id = 1,
                FechaTransaccion = new DateTime(2022, 1, 7),
                Price = 157,
                TipoPago = TipoPago.Tarjeta,
                Ultimos4Difitos = "1234"
            };
            var pago2 = new PagoTarjeta()
            {
                Id = 2,
                FechaTransaccion = new DateTime(2022, 8, 8),
                Price = 91.9m,
                TipoPago = TipoPago.Tarjeta,
                Ultimos4Difitos = "4321"
            };

            builder.HasData(pago1, pago2);
        }
    }
}
