using gad.aaportal.models.Entity.Dinardap;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gad.aaportal.dataaccess.Configuration.Dinardap
{
    public class SriContadorConfig : IEntityTypeConfiguration<SriContador>
    {
        public void Configure(EntityTypeBuilder<SriContador> b)
        {
            b.ToTable("sri_contador", "Dinardap");
            b.HasKey(x => x.NumeroRuc);
            b.Property(x => x.FechaGrabado).HasColumnName("fecha_grabado");
        }
    }
}
