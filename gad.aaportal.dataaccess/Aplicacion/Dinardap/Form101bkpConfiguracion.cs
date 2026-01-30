using gad.aaportal.models.Entity.Dinardap;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gad.aaportal.dataaccess.Aplicacion.Dinardap
{
    public class Form101Configuracionbkp : IEntityTypeConfiguration<Form101bkp>
    {
        public void Configure(EntityTypeBuilder<Form101bkp> entity)
        {
            entity.ToTable("Form101bkp", "Dinardap");

            entity.HasKey(e => new { e.AnioFiscal, e.NumeroIdentificacion, e.FechaInsert })
                  .HasName("PK_Form101bkp");

            entity.Property(e => e.AnioFiscal).HasColumnName("anioFiscal");
            entity.Property(e => e.NumeroIdentificacion)
                  .HasMaxLength(20)
                  .HasColumnName("numeroIdentificacion");

            entity.Property(e => e.RazonSocial)
                  .HasMaxLength(200)
                  .HasColumnName("razonSocial");

            entity.Property(e => e.PerdidaEjercicio3430).HasColumnName("perdidaEjercicio3430");
            entity.Property(e => e.TotActivoNoCorriente1077).HasColumnName("totActivoNoCorriente1077");
            entity.Property(e => e.TotPasivosCorrientes1340).HasColumnName("totPasivosCorrientes1340");
            entity.Property(e => e.TotalActivo1080).HasColumnName("totalActivo1080");
            entity.Property(e => e.TotalActivoCorriente470).HasColumnName("totalActivoCorriente470");
            entity.Property(e => e.TotalIngresos1930).HasColumnName("totalIngresos1930");
            entity.Property(e => e.TotalPasivos1620).HasColumnName("totalPasivos1620");
            entity.Property(e => e.TotalPatrimonioNeto1780).HasColumnName("totalPatrimonioNeto1780");
            entity.Property(e => e.TotasCostosGastos3380).HasColumnName("totasCostosGastos3380");
            entity.Property(e => e.UtilidadEjercicio3420).HasColumnName("utilidadEjercicio3420");
            entity.Property(e => e.TotalPasivosLargoPlazo1590).HasColumnName("totalPasivosLargoPlazo1590");
            entity.Property(e => e.ProNoctePasCtgComNeg1577).HasColumnName("proNoctePasCtgComNeg1577");

            entity.Property(e => e.FechaInsert)
                  .HasColumnType("datetime")
                  .HasColumnName("fechaInsert");
        }
    }
}
