using gad.aaportal.models.Entity.Dinardap;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gad.aaportal.dataaccess.Aplicacion.Dinardap
{
    public class Form102Configuracion : IEntityTypeConfiguration<Form102>
    {
        public void Configure(EntityTypeBuilder<Form102> builder)
        {
            builder.ToTable("Form102", "Dinardap");

            builder.HasKey(x => new { x.AnioFiscal, x.NumeroIdentificacion });

            builder.Property(x => x.NumeroIdentificacion).HasMaxLength(20);
            builder.Property(x => x.RazonSocial).HasMaxLength(150);
            builder.Property(x => x.SustitutivaOriginal).HasMaxLength(50);

            builder.Property(x => x.FechaInsercion)
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.FechaActualizacion);
        }
    }
}
