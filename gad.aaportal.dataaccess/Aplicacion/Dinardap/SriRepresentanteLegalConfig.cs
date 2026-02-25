using gad.aaportal.models.Entity.Dinardap;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gad.aaportal.dataaccess.Aplicacion.Dinardap
{
    public class SriRepresentanteLegalConfig : IEntityTypeConfiguration<SriRepresentanteLegal>
    {
        public void Configure(EntityTypeBuilder<SriRepresentanteLegal> b)
        {
            b.ToTable("sri_representante_legal", "Dinardap");
            b.HasKey(x => x.NumeroRuc);
            b.Property(x => x.FechaGrabado).HasColumnName("fecha_grabado");
        }
    }
}
