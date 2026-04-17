using gad.aaportal.models.Entity.Dinardap;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gad.aaportal.dataaccess.Configuration.Dinardap
{
    public class SepsOrganizacionConfig : IEntityTypeConfiguration<SepsOrganizacion>
    {
        public void Configure(EntityTypeBuilder<SepsOrganizacion> builder)
        {
            builder.ToTable("SepsOrganizacion", "Dinardap");

            builder.HasKey(x => x.Ruc);

            builder.Property(x => x.Ruc)
                .HasMaxLength(13)
                .IsRequired();

            builder.Property(x => x.Error)
                .HasMaxLength(500);

            builder.Property(x => x.RazonSocial)
                .HasMaxLength(300);

            builder.Property(x => x.FechaGrabado)
                .HasColumnName("fecha_grabado")
                .HasDefaultValueSql("SYSDATETIME()");

            builder.Property(x => x.FechaRegistroSeps)
                .HasColumnType("date");
        }
    }
}
