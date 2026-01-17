using gad.aaportal.models.Entity.Aplicacion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gad.aaportal.dataaccess.Aplicacion.Aplicacion
{
    public class DistribucionPagoConfiguracion : IEntityTypeConfiguration<DistribucionPago>
    {
        public void Configure(EntityTypeBuilder<DistribucionPago> builder)
        {
            builder.ToTable("DistribucionPago", schema: "Aplicacion");

            builder.HasKey(x => new { x.RUC, x.AnioFiscal, x.Canton });

            builder.Property(c => c.RUC)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(c => c.AnioFiscal)
                .IsRequired();

            builder.Property(c => c.Canton)
                .IsRequired();

            builder.Property(c => c.Paga)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(t => t.Porcentaje)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        }
    }
}
