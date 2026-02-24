using gad.aaportal.models.Entity.Dinardap;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gad.aaportal.dataaccess.Aplicacion.Dinardap
{
    public class SriRucEstablecimientoConfig : IEntityTypeConfiguration<SriRucEstablecimiento>
    {
        public void Configure(EntityTypeBuilder<SriRucEstablecimiento> builder)
        {
            builder.ToTable("sri_ruc_establecimientos", "Dinardap");

            // PK compuesta
            builder.HasKey(x => new { x.NumeroRuc, x.NumeroEstablecimiento });

            // nombres de columnas exactamente como en BD
            builder.Property(x => x.NumeroRuc).HasColumnName("numeroRuc");
            builder.Property(x => x.NumeroEstablecimiento).HasColumnName("numeroEstablecimiento");

            builder.Property(x => x.Calle).HasColumnName("calle");
            builder.Property(x => x.EstadoEstablecimiento).HasColumnName("estadoEstablecimiento");
            builder.Property(x => x.Interseccion).HasColumnName("interseccion");
            builder.Property(x => x.NombreFantasiaComercial).HasColumnName("nombreFantasiaComercial");
            builder.Property(x => x.TipoEstablecimiento).HasColumnName("tipoEstablecimiento");
            builder.Property(x => x.ReferenciaUbicacion).HasColumnName("referenciaUbicacion");

            builder.Property(x => x.FechaInicioActividades).HasColumnName("fechaInicioActividades");
            builder.Property(x => x.FechaReinicioActividades).HasColumnName("fechaReinicioActividades");
            builder.Property(x => x.FechaCierre).HasColumnName("fechaCierre");

            builder.Property(x => x.VerificacionUbicacion).HasColumnName("verificacionUbicacion");
            builder.Property(x => x.UbicacionGeografica).HasColumnName("ubicacionGeografica");

            builder.Property(x => x.Barrio).HasColumnName("barrio");
            builder.Property(x => x.Ciudadela).HasColumnName("ciudadela");
            builder.Property(x => x.Conjunto).HasColumnName("conjunto");
            builder.Property(x => x.Bloque).HasColumnName("bloque");
            builder.Property(x => x.NombreEdificio).HasColumnName("nombreEdificio");
            builder.Property(x => x.NumeroOficina).HasColumnName("numeroOficina");
            builder.Property(x => x.Manzana).HasColumnName("manzana");
            builder.Property(x => x.Supermanzana).HasColumnName("supermanzana");
            builder.Property(x => x.Kilometro).HasColumnName("kilometro");
            builder.Property(x => x.Carretero).HasColumnName("carretero");
            builder.Property(x => x.Camino).HasColumnName("camino");
            builder.Property(x => x.NumeroPiso).HasColumnName("numeroPiso");
            builder.Property(x => x.ResultadoVerificacion).HasColumnName("resultadoVerificacion");
            builder.Property(x => x.DireccionPresunta).HasColumnName("direccionPresunta");

            builder.Property(x => x.FechaGrabado)
                   .HasColumnName("fecha_grabado")
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
