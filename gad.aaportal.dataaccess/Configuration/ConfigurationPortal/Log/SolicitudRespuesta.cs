using gad.aaportal.models.Entity.Log;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gad.aaportal.dataaccess.Configuration
{
    public class SolicitudRespuestaConfiguration : IEntityTypeConfiguration<SolicitudRespuesta>
    {
        public void Configure(EntityTypeBuilder<SolicitudRespuesta> entity)
        {
            entity.ToTable("SolicitudRespuesta", "Log");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Codigo).HasMaxLength(50)
                .HasColumnName("codigo");

            entity.Property(e => e.CodigoUsuario)
                .HasMaxLength(50)
                .HasColumnName("codigoUsuario");

            entity.Property(e => e.Exito).HasColumnName("exito");

            entity.Property(e => e.FechaHoraEnvio)
                .HasColumnType("datetime")
                .HasColumnName("fechaHoraEnvio");

            entity.Property(e => e.FechaHoraRespuesta)
                .HasColumnType("datetime")
                .HasColumnName("fechaHoraRespuesta");

            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");

            entity.Property(e => e.Mensaje)
                .HasMaxLength(500)
                .HasColumnName("mensaje");

            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(13)
                .HasColumnName("numeroDocumento");

            entity.Property(e => e.Proveedor)
                .HasMaxLength(500)
                .HasColumnName("proveedor");

            entity.Property(e => e.Metodo)
                .HasMaxLength(100)
                .HasColumnName("metodo");

            entity.Property(e => e.Secuencial).HasColumnName("secuencial");

            entity.Property(e => e.TramaEnvio).HasColumnName("tramaEnvio");

            entity.Property(e => e.TramaRespuesta).HasColumnName("tramaRespuesta");
        }

    }
}
