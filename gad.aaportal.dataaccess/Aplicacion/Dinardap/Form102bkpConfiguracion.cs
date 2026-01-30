using gad.aaportal.models.Entity.Dinardap;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gad.aaportal.dataaccess.Aplicacion.Dinardap
{
    public class Form102bkpConfiguracion : IEntityTypeConfiguration<Form102bkp>
    {
        public void Configure(EntityTypeBuilder<Form102bkp> builder)
        {
            builder.ToTable("Form102bkp", "Dinardap");

            builder.HasKey(x => new { x.AnioFiscal, x.NumeroIdentificacion, x.FechaInsercion });

            builder.Property(x => x.NumeroIdentificacion).HasMaxLength(20);
            builder.Property(x => x.RazonSocial).HasMaxLength(150);
            builder.Property(x => x.SustitutivaOriginal).HasMaxLength(50);

            builder.Property(x => x.FechaInsercion)
                   .HasDefaultValueSql("GETDATE()");
        }
    }
}
