using gad.aaportal.models.Configuration.Seguridad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.dataaccess.Configuration
{
    public class JwtConfiguracion : IEntityTypeConfiguration<Jwt>
    {
        public void Configure(EntityTypeBuilder<Jwt> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK_Seguridad_Jwt");

            entity.ToTable("Jwt", "Seguridad");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.JwtTime).HasColumnName("jwtTime");
            entity.Property(e => e.SecurityKey).HasColumnName("securityKey");
        }
    }
}
