using gad.aaportal.models.Entity.Seguridad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gad.aaportal.dataaccess.Configuration;

public class UsuarioConfiguracion : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> entity)
    {
        entity.HasKey(e => e.User);

        entity.ToTable("Usuario", "Seguridad");

        entity.Property(e => e.User)
            .HasMaxLength(50)
            .HasColumnName("user");
        entity.Property(e => e.CambiaClave).HasColumnName("cambiaClave");
        entity.Property(e => e.DiasParaCambiarClave).HasColumnName("diasParaCambiarClave");
        entity.Property(e => e.Email)
            .HasMaxLength(50)
            .HasColumnName("email");
        entity.Property(e => e.EstaBloqueado).HasColumnName("estaBloqueado");
        entity.Property(e => e.Estado).HasColumnName("estado");
        entity.Property(e => e.Fecha)
            .HasColumnType("datetime")
            .HasColumnName("fecha");
        entity.Property(e => e.FechaUltimoCambioClave)
            .HasColumnType("datetime")
            .HasColumnName("fechaUltimoCambioClave");
        entity.Property(e => e.Nombres)
            .HasMaxLength(50)
            .HasColumnName("nombres");
        entity.Property(e => e.Password)
            .HasMaxLength(50)
            .HasColumnName("password");
    }
}
