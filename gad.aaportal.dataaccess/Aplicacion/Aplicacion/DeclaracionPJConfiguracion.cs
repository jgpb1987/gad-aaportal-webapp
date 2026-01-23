using gad.aaportal.models.Entity.Aplicacion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gad.aaportal.dataaccess.Aplicacion.Aplicacion
{
    public class DeclaracionPJConfiguracion : IEntityTypeConfiguration<DeclaracionPJ>
    {
        public void Configure(EntityTypeBuilder<DeclaracionPJ> builder)
        {
            builder.ToTable("DeclaracionPJ", "Aplicacion");

            builder.HasKey(x => new { x.RUC, x.AnioFiscal });

            builder.Property(x => x.RUC)
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(x => x.AnioFiscal)
                   .IsRequired();

            builder.Property(x => x.TotalActivoCorriente470).HasColumnType("decimal(18,2)");
            builder.Property(x => x.TotActivoNoCorriente1077).HasColumnType("decimal(18,2)");
            builder.Property(x => x.TotalActivo1080).HasColumnType("decimal(18,2)");
            builder.Property(x => x.TotPasivosCorrientes1340).HasColumnType("decimal(18,2)");
            builder.Property(x => x.TotalPasivosLargoPlazo1590).HasColumnType("decimal(18,2)");
            builder.Property(x => x.TotalPasivosContingente).HasColumnType("decimal(18,2)");
            builder.Property(x => x.TotalPasivos1620).HasColumnType("decimal(18,2)");
            builder.Property(x => x.TotalIngresos1930).HasColumnType("decimal(18,2)");
            builder.Property(x => x.TotasCostosGastos3380).HasColumnType("decimal(18,2)");
            builder.Property(x => x.UtilidadEjercicio3420).HasColumnType("decimal(18,2)");
            builder.Property(x => x.ValorUnoPorMil).HasColumnType("decimal(18,2)");
            builder.Property(x => x.ValorPatente).HasColumnType("decimal(18,2)");

            builder.Property(x => x.FechaInser)
                   .HasColumnType("datetime")
                   .IsRequired();

            builder.Property(x => x.FechaUpdate)
                   .HasColumnType("datetime");
        }
    }
}
