using gad.aaportal.models.Entity.Dinardap;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gad.aaportal.dataaccess.Configuration.Dinardap
{
    public class SriActividadEconomicaConfig : IEntityTypeConfiguration<SriActividadEconomica>
    {
        public void Configure(EntityTypeBuilder<SriActividadEconomica> b)
        {
            b.ToTable("sri_actividad_economica", "Dinardap");
            b.HasKey(x => x.NumeroRuc);
            b.Property(x => x.FechaGrabado).HasColumnName("fecha_grabado");
        }
    }
}
