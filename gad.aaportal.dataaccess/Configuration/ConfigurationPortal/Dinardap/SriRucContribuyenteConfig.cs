using gad.aaportal.models.Entity.Dinardap;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gad.aaportal.dataaccess.Configuration.Dinardap
{
    public class SriRucContribuyenteConfig : IEntityTypeConfiguration<SriRucContribuyente>
    {
        public void Configure(EntityTypeBuilder<SriRucContribuyente> builder)
        {
            builder.ToTable("SriRucContribuyente", "Dinardap");

            builder.HasNoKey(); // importante: la tabla no tiene PK

            builder.Property(x => x.ClaseContribuyente).HasMaxLength(50);
            builder.Property(x => x.CodigoClaseContribuyente).HasMaxLength(10);
            builder.Property(x => x.CodigoEstadoContribuyente).HasMaxLength(10);
            builder.Property(x => x.EstadoContribuyente).HasMaxLength(20);
            builder.Property(x => x.EstadoPersona).HasMaxLength(20);
            builder.Property(x => x.EstadoSociedad).HasMaxLength(20);
            builder.Property(x => x.Obligado).HasMaxLength(5);
            builder.Property(x => x.PersonaSociedad).HasMaxLength(10);
            builder.Property(x => x.NumeroRegistroMercantil).HasMaxLength(50);
            builder.Property(x => x.CapitalSuscrito).HasMaxLength(50);
            builder.Property(x => x.CategoriaRise).HasMaxLength(20);
            builder.Property(x => x.ComercioExterior).HasMaxLength(10);
            builder.Property(x => x.NumRucSociedadAdscrita).HasMaxLength(20);
            builder.Property(x => x.NumRucSociedadEscisionada).HasMaxLength(20);
            builder.Property(x => x.NumeroRucFusionado).HasMaxLength(20);
            builder.Property(x => x.NumeroPatronal).HasMaxLength(20);
            builder.Property(x => x.NumeroExpediente).HasMaxLength(50);
            builder.Property(x => x.OrigenSociedad).HasMaxLength(50);
            builder.Property(x => x.GerenteGeneral).HasMaxLength(200);
            builder.Property(x => x.NumeroRegistroColegioGremio).HasMaxLength(50);

            builder.Property(x => x.FechaRegistro)
                   .HasDefaultValueSql("SYSDATETIME()");
        }
    }
}
