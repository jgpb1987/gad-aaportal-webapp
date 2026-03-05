using gad.aaportal.models.Entity.Aplicacion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gad.aaportal.dataaccess.Configuration.Aplicacion
{
    public class TasaAdministrativaConfiguracion : IEntityTypeConfiguration<TasaAdministrativa>
    {
        public void Configure(EntityTypeBuilder<TasaAdministrativa> builder)
        {
            builder.ToTable("TasaAdministrativa", "Aplicacion");

            builder.HasKey(t => t.Concepto);

            builder.Property(t => t.Concepto)
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(t => t.Valor)
                .HasColumnType("decimal(18,2)");
        }
    }
}