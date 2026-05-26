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
    public class ContribuyenteMedioContactoConfiguracion : IEntityTypeConfiguration<ContribuyenteMedioContacto>
    {
        public void Configure(EntityTypeBuilder<ContribuyenteMedioContacto> entity)
        {
            entity.HasKey(e => e.IdMedioContacto);

            entity.ToTable("ContribuyenteMedioContacto", "Declaracion");

            entity.Property(e => e.CodigoTipoMedioContacto).HasMaxLength(50);

            entity.Property(e => e.Estado)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Identificacion).HasMaxLength(13);

            entity.Property(e => e.Valor).HasMaxLength(200);

            entity.HasOne(d => d.CodigoTipoMedioContactoNavigation)
                .WithMany(p => p.ContribuyenteMedioContactos)
                .HasForeignKey(d => d.CodigoTipoMedioContacto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContribuyenteMedioContacto_TipoMedioContacto");

            entity.HasOne(d => d.IdentificacionNavigation)
                .WithMany(p => p.ContribuyenteMedioContactos)
                .HasForeignKey(d => d.Identificacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContribuyenteMedioContacto_Contribuyente");
        }
    }
}
