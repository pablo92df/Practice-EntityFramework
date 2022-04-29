using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entities.Configurations
{
    public class PagoPaypalConfig : IEntityTypeConfiguration<PagoPaypal>
    {
        public void Configure(EntityTypeBuilder<PagoPaypal> builder)
        {
            builder.Property(p=>p.CorreoElectronico).HasMaxLength(150).IsRequired();

            var pago1 = new PagoPaypal()
            {
                Id = 3,
                FechaTransaccion = new DateTime(2022, 1, 7),
                Price = 157,
                TipoPago = TipoPago.Paypal,
                CorreoElectronico = "pablito@gmail.com"
            };
            var pago2 = new PagoPaypal()
            {
                Id = 4,
                FechaTransaccion = new DateTime(2022, 8, 8),
                Price = 9.9m,
                TipoPago = TipoPago.Paypal,
                CorreoElectronico = "pablito@gmail.com"
            };

            builder.HasData(pago1, pago2);
        }
    }
}
