using gad.aaportal.models.Entity.Seguridad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gad.aaportal.dataaccess.Configuration;

public class UsuarioSesionConfiguracion : IEntityTypeConfiguration<UsuarioSesion>
{
    public void Configure(EntityTypeBuilder<UsuarioSesion> entity)
    {
        entity.HasKey(e => e.Jti).HasName("PK_Seguridad_Usuario_Sesion");

        entity.ToTable("Usuario_Sesion", "Seguridad");

        entity.Property(e => e.Jti)
            .HasMaxLength(50)
            .HasColumnName("jti");
        entity.Property(e => e.Accion)
        .HasMaxLength(200)
        .HasDefaultValue("")
        .HasColumnName("accion");
        entity.Property(e => e.Browser)
            .HasMaxLength(100)
            .HasColumnName("browser");
        entity.Property(e => e.CodigoUser)
            .HasMaxLength(50)
            .HasColumnName("codigoUser");
        entity.Property(e => e.EstaRevocado).HasColumnName("estaRevocado");
        entity.Property(e => e.Fecha).HasColumnName("fecha");
        entity.Property(e => e.FechaExpiracion)
            .HasColumnType("datetime")
            .HasColumnName("fechaExpiracion");
        entity.Property(e => e.FechaHora)
            .HasColumnType("datetime")
            .HasColumnName("fechaHora");
        entity.Property(e => e.FechaRevocatoria)
            .HasColumnType("datetime")
            .HasColumnName("fechaRevocatoria");
        entity.Property(e => e.Geolocation)
            .HasMaxLength(50)
            .HasColumnName("geolocation");
        entity.Property(e => e.Ip)
            .HasMaxLength(20)
            .HasColumnName("ip");
        entity.Property(e => e.Language)
            .HasMaxLength(50)
            .HasColumnName("language");
        entity.Property(e => e.OperatingSystem)
            .HasMaxLength(100)
            .HasColumnName("operatingSystem");
        entity.Property(e => e.Plugins)
            .HasMaxLength(200)
            .HasColumnName("plugins");
        entity.Property(e => e.TimeZone)
            .HasMaxLength(50)
            .HasColumnName("timeZone");
        entity.Property(e => e.UserAgent)
            .HasMaxLength(200)
            .HasColumnName("userAgent");

        entity.HasOne(d => d.CodigoUserNavigation).WithMany(p => p.UsuarioSesion)
            .HasForeignKey(d => d.CodigoUser)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Seguridad_Usuario_Sesion_Usuario");
    }
}
