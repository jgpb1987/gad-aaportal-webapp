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
    public class ContribuyenteUsuarioConfiguracion : IEntityTypeConfiguration<ContribuyenteUsuario>
    {
        public void Configure(EntityTypeBuilder<ContribuyenteUsuario> entity)
        {
            entity.HasKey(e => new { e.Identificacion, e.Usuario });

            entity.ToTable("ContribuyenteUsuario", "Declaracion");

            entity.Property(e => e.Identificacion).HasMaxLength(13);

            entity.Property(e => e.Usuario).HasMaxLength(50);

            entity.Property(e => e.Estado)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdentificacionNavigation)
                .WithMany(p => p.ContribuyenteUsuarios)
                .HasForeignKey(d => d.Identificacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContribuyenteUsuario_Contribuyente");

            entity.HasOne(d => d.UsuarioNavigation)
                .WithMany(p => p.ContribuyenteUsuarios)
                .HasForeignKey(d => d.Usuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContribuyenteUsuario_Usuario");
        }
    }
}
