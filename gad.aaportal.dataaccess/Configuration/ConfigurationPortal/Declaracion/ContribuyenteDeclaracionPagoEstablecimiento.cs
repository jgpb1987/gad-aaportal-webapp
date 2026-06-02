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
    public class ContribuyenteDeclaracionPagoEstablecimientoConfiguracion : IEntityTypeConfiguration<ContribuyenteDeclaracionPagoEstablecimiento>
    {
        public void Configure(EntityTypeBuilder<ContribuyenteDeclaracionPagoEstablecimiento> entity)
        {
            entity.ToTable("ContribuyenteDeclaracionPagoEstablecimiento", "Declaracion");

            entity.Property(e => e.Canton).HasMaxLength(100);

            entity.Property(e => e.Parroquia).HasMaxLength(100);

            entity.Property(e => e.Porcentaje).HasColumnType("decimal(8, 2)");

            entity.Property(e => e.Provincia).HasMaxLength(100);

            entity.Property(e => e.Valor).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdContribuyenteDeclaracionNavigation)
                .WithMany(p => p.ContribuyenteDeclaracionPagoEstablecimientos)
                .HasForeignKey(d => d.IdContribuyenteDeclaracion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContribuyenteDeclaracionPagoEstablecimiento_ContribuyenteDeclaracion");
        }
    }
}
