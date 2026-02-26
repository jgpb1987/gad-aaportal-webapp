using gad.aaportal.models.Entity.Dinardap;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gad.aaportal.dataaccess.Configuration.Dinardap
{
    public class SriRucListaBlancaConfig : IEntityTypeConfiguration<SriRucListaBlanca>
    {
        public void Configure(EntityTypeBuilder<SriRucListaBlanca> builder)
        {
            builder.ToTable("sri_ruc_lista_blanca", "Dinardap");

            builder.HasKey(x => x.NumeroRuc);

            builder.Property(x => x.NumeroRuc)
                   .HasColumnName("numeroRuc");

            builder.Property(x => x.MarcaListaBlanca)
                   .HasColumnName("marcaListaBlanca");

            builder.Property(x => x.FechaGrabado)
                   .HasColumnName("fecha_grabado")
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
