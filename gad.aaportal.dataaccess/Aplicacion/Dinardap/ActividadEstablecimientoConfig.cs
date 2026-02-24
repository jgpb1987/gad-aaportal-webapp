using gad.aaportal.models.Entity.Dinardap;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gad.aaportal.dataaccess.Aplicacion.Dinardap
{
    public class ActividadEstablecimientoConfig : IEntityTypeConfiguration<ActividadEstablecimiento>
    {
        public void Configure(EntityTypeBuilder<ActividadEstablecimiento> builder)
        {
            builder.ToTable("actividades_establecimiento", "dinardap");

            builder.HasKey(x => new
            {
                x.NumeroRuc,
                x.NumeroEstablecimiento,
                x.CodigoActividad
            });

            builder.Property(x => x.NumeroRuc)
                   .HasColumnName("numero_ruc")
                   .HasMaxLength(13)
                   .IsRequired();

            builder.Property(x => x.NumeroEstablecimiento)
                   .HasColumnName("numero_establecimiento");

            builder.Property(x => x.CodigoActividad)
                   .HasColumnName("codigo_actividad")
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(x => x.ActividadEconomica)
                   .HasColumnName("actividad_economica");

            builder.Property(x => x.FechaRegistro)
                   .HasColumnName("fecha_registro")
                   .HasDefaultValueSql("SYSDATETIME()");
        }
    }
}
