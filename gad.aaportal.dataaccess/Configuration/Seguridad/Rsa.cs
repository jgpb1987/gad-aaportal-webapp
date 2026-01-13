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
    public class RsaConfiguracion : IEntityTypeConfiguration<Rsa>
    {
        public void Configure(EntityTypeBuilder<Rsa> entity)
        {
            entity.ToTable("Rsa", "Seguridad");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.PrivateKey).HasColumnName("privateKey");
            entity.Property(e => e.PublicKey).HasColumnName("publicKey");
        }
    }
}
