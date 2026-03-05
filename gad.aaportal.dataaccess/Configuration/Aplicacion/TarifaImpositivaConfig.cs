using gad.aaportal.models.Entity.Aplicacion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gad.aaportal.dataaccess.Configuration.Aplicacion
{
    public class TarifaImpositivaConfig : IEntityTypeConfiguration<TarifaImpositiva>
    {
        public void Configure(EntityTypeBuilder<TarifaImpositiva> builder)
        {
            builder.ToTable("TarifaImpositiva", "Aplicacion");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd();

            builder.Property(t => t.Desde)
                .HasColumnType("decimal(18,5)")
                .IsRequired();

            builder.Property(t => t.Hasta)
                .HasColumnType("decimal(18,5)")
                .IsRequired();

            builder.Property(t => t.Impuesto)
                .HasColumnType("decimal(18,5)")
                .IsRequired();

            builder.Property(t => t.Excedente)
                .HasColumnType("decimal(18,5)")
                .IsRequired();
        }
    }
}
