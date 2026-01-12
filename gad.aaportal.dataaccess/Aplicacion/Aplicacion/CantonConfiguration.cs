using gad.aaportal.models.Entity.Aplicacion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gad.aaportal.dataaccess.Aplicacion.Aplicacion
{
    public class CantonConfiguration : IEntityTypeConfiguration<Canton>
    {
        public void Configure(EntityTypeBuilder<Canton> builder)
        {
            builder.ToTable("Cantones", schema: "Aplicacion");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Provincia)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Nombre)
                .HasColumnName("canton")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
