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

            builder.HasKey(x => new { x.RUC, x.AnioFiscal, x.Id });

            builder.Property(c => c.RUC)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(c => c.AnioFiscal)
                .IsRequired();

            builder.Property(c => c.Id)
                .IsRequired();

            builder.Property(c => c.PagoAA)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(t => t.Porcentaje)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
            builder.Property(t => t.Valor)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        }
    }
}
