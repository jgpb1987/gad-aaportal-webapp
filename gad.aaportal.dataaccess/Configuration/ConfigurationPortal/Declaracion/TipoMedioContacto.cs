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
    public class TipoMedioContactoConfiguracion : IEntityTypeConfiguration<TipoMedioContacto>
    {
        public void Configure(EntityTypeBuilder<TipoMedioContacto> entity)
        {
            entity.HasKey(e => e.Codigo);

            entity.ToTable("TipoMedioContacto", "Declaracion");

            entity.Property(e => e.Codigo).HasMaxLength(50);

            entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .HasDefaultValueSql("('')");

            entity.Property(e => e.Estado)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Nombre).HasMaxLength(100);
        }
    }
}
