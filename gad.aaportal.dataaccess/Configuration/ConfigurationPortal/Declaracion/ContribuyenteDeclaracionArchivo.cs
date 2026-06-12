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
    public class ContribuyenteDeclaracionArchivoConfiguracion : IEntityTypeConfiguration<ContribuyenteDeclaracionArchivo>
    {
        public void Configure(EntityTypeBuilder<ContribuyenteDeclaracionArchivo> entity)
        {
            entity.ToTable("ContribuyenteDeclaracionArchivos", "Declaracion");

            entity.Property(e => e.ExtensionArchivo).HasMaxLength(50);

            entity.Property(e => e.FechaHora).HasColumnType("datetime");

            entity.Property(e => e.NombreArchivo).HasMaxLength(200);

            entity.Property(e => e.UbicacionArchivo).HasMaxLength(500);

            entity.HasOne(d => d.IdContribuyenteDeclaracionNavigation)
                .WithMany(p => p.ContribuyenteDeclaracionArchivos)
                .HasForeignKey(d => d.IdContribuyenteDeclaracion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContribuyenteDeclaracionArchivos_ContribuyenteDeclaracion");
        }
    }
}
