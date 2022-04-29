using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entities.Configurations
{
    public class PagoConfig : IEntityTypeConfiguration<Pago>
    {
        public void Configure(EntityTypeBuilder<Pago> builder)
        {
            //entity framework lo usa para distinguir que tipo de es
            builder.HasDiscriminator(p => p.TipoPago)
                .HasValue<PagoPaypal>(TipoPago.Paypal)
                .HasValue<PagoTarjeta>(TipoPago.Tarjeta);

            builder.Property(p => p.Price).HasPrecision(18, 2);
        }
    }
}
