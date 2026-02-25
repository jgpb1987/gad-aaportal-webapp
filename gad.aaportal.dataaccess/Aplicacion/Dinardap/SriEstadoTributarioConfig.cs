using gad.aaportal.models.Entity.Dinardap;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gad.aaportal.dataaccess.Aplicacion.Dinardap
{
    public class SriEstadoTributarioConfig : IEntityTypeConfiguration<SriEstadoTributario>
    {
        public void Configure(EntityTypeBuilder<SriEstadoTributario> builder)
        {
            builder.ToTable("sri_estado_tributario", "Dinardap");

            builder.HasKey(x => x.NumeroRuc);

            builder.Property(x => x.Estado)
                   .HasMaxLength(5);

            builder.Property(x => x.Descripcion)
                   .HasMaxLength(200);

            builder.Property(x => x.FechaGrabado).HasColumnName("fecha_grabado");
        }
    }
}
