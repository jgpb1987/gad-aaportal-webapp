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
    public class ContribuyenteEstablecimientoConfiguracion : IEntityTypeConfiguration<ContribuyenteEstablecimiento>
    {
        public void Configure(EntityTypeBuilder<ContribuyenteEstablecimiento> entity)
        {
            entity.ToTable("ContribuyenteEstablecimiento", "Declaracion");

            entity.Property(e => e.Calles).HasMaxLength(200);

            entity.Property(e => e.Canton).HasMaxLength(100);

            entity.Property(e => e.DireccionCompleta).HasMaxLength(300);

            entity.Property(e => e.Estado).HasMaxLength(50);

            entity.Property(e => e.Identificacion).HasMaxLength(13);

            entity.Property(e => e.Matriz).HasMaxLength(50);

            entity.Property(e => e.NombreFantasiaComercial).HasMaxLength(300);

            entity.Property(e => e.NumeroEstablecimiento).HasMaxLength(50);

            entity.Property(e => e.Parroquia).HasMaxLength(100);

            entity.Property(e => e.Provincia).HasMaxLength(100);

            entity.HasOne(d => d.IdentificacionNavigation)
                .WithMany(p => p.ContribuyenteEstablecimientos)
                .HasForeignKey(d => d.Identificacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContribuyenteEstablecimiento_Constrinuyente");
        }
    }
}
