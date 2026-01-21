using gad.aaportal.models.Entity.Seguridad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.dataaccess.Configuration
{
    public class ConfiguracionEmailConfiguracion : IEntityTypeConfiguration<ConfiguracionEmail>
    {
        public void Configure(EntityTypeBuilder<ConfiguracionEmail> entity)
        {
            entity.ToTable("ConfiguracionEmail", "Seguridad");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Puerto)
                .HasMaxLength(100)
                .HasColumnName("puerto");
            entity.Property(e => e.Pwd)
                .HasMaxLength(100)
                .HasColumnName("pwd");
            entity.Property(e => e.Servidor)
                .HasMaxLength(100)
                .HasColumnName("servidor");
        }
    }
}
