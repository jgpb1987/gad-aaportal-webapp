using gad.aaportal.models.Entity.Declaracion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.dataaccess.Configuration
{
    public class ContribuyenteDeclaracionConfiguracion : IEntityTypeConfiguration<ContribuyenteDeclaracion>
    {
        public void Configure(EntityTypeBuilder<ContribuyenteDeclaracion> entity)
        {
            entity.ToTable("ContribuyenteDeclaracion", "Declaracion");

            entity.Property(e => e.ActivoCorriente).HasColumnType("decimal(18, 6)");

            entity.Property(e => e.ActivoNoCorriente).HasColumnType("decimal(18, 6)");

            entity.Property(e => e.CodigoUnicoPago).HasMaxLength(20);

            entity.Property(e => e.CostosGastos).HasColumnType("decimal(18, 6)");

            entity.Property(e => e.Fecha).HasColumnType("date");

            entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

            entity.Property(e => e.Identificacion).HasMaxLength(13);

            entity.Property(e => e.Ingresos).HasColumnType("decimal(18, 6)");

            entity.Property(e => e.PasivoContingente).HasColumnType("decimal(18, 6)");

            entity.Property(e => e.PasivoCorriente).HasColumnType("decimal(18, 6)");

            entity.Property(e => e.PasivoNoCorriente).HasColumnType("decimal(18, 6)");

            entity.Property(e => e.Patente).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.ValorBomberos).HasColumnType("decimal(18, 6)");

            entity.Property(e => e._15XMil)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("1_5_x_Mil");

            entity.HasOne(d => d.IdentificacionNavigation)
                .WithMany(p => p.ContribuyenteDeclaracions)
                .HasForeignKey(d => d.Identificacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContribuyenteDeclaracion_Contribuyente");
        }
    }
}
