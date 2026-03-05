using gad.aaportal.models.Entity.Dinardap;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gad.aaportal.dataaccess.Configuration.Dinardap
{
    public class SriTipoContribuyenteConfig : IEntityTypeConfiguration<SriTipoContribuyente>
    {
        public void Configure(EntityTypeBuilder<SriTipoContribuyente> b)
        {
            b.ToTable("sri_tipo_contribuyente", "Dinardap");
            b.HasKey(x => x.NumeroRuc);
            b.Property(x => x.FechaGrabado).HasColumnName("fecha_grabado");
        }
    }
}
