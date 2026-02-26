using gad.aaportal.models.Entity.Dinardap;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gad.aaportal.dataaccess.Configuration.Dinardap
{
    public class SriEstructuraOrganizacionalConfig : IEntityTypeConfiguration<SriEstructuraOrganizacional>
    {
        public void Configure(EntityTypeBuilder<SriEstructuraOrganizacional> b)
        {
            b.ToTable("sri_estructura_organizacional", "Dinardap");
            b.HasKey(x => x.NumeroRuc);
            b.Property(x => x.FechaGrabado).HasColumnName("fecha_grabado");
        }
    }
}
