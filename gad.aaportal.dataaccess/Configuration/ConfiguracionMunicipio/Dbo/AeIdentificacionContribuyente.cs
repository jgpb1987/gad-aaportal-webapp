using gad.aaportal.models.Entity.Dbo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.dataaccess.Configuration.Dbo
{
    public class AeIdentificacionContribuyenteConfiguracion : IEntityTypeConfiguration<AeIdentificacionContribuyente>
    {
        public void Configure(EntityTypeBuilder<AeIdentificacionContribuyente> entity)
        {
            entity.HasKey(e => e.Ruc)
                .HasName("PK_AE_IDENTIFICACIONCONTRIBUYE");

            entity.ToTable("AE_IdentificacionContribuyente");

            entity.Property(e => e.Ruc).HasMaxLength(20);

            entity.Property(e => e.CiPropietarioRepresentante).HasMaxLength(13);

            entity.Property(e => e.Contabilidad)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasComment("'S' Si esta obligado a llevar contabilidad\r\n'N' si no esta obligado a llevar contabilidad");

            entity.Property(e => e.EstadoRuc)
                .HasMaxLength(1)
                .IsUnicode(false);

            entity.Property(e => e.FechaInicioActividades).HasColumnType("datetime");
            entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

            entity.Property(e => e.Observaciones)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.Property(e => e.RazonSocial).HasMaxLength(250);
            entity.Property(e => e.Rise).HasMaxLength(1);
            entity.Property(e => e.UsuarioRegistro).HasMaxLength(30);

            //entity.Ignore(e => e.CiPropietarioRepresentanteNavigation);
            //entity.Ignore(e => e.EstadoRucNavigation);
            //entity.Ignore(e => e.IdPersoneriaNavigation);
        }
    }
}
