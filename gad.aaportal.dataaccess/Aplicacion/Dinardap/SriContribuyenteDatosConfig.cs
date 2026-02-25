using gad.aaportal.models.Entity.Dinardap;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gad.aaportal.dataaccess.Aplicacion.Dinardap
{
    public class SriContribuyenteDatosConfig : IEntityTypeConfiguration<SriContribuyenteDatos>
    {
        public void Configure(EntityTypeBuilder<SriContribuyenteDatos> b)
        {
            b.ToTable("sri_contribuyente_datos", "Dinardap");

            b.HasKey(x => x.NumeroRuc);

            b.Property(x => x.NumeroRuc).HasColumnName("numeroRuc");
            b.Property(x => x.CodClaseContrib).HasColumnName("codClaseContrib");
            b.Property(x => x.CodEstado).HasColumnName("codEstado");
            b.Property(x => x.DesClaseContrib).HasColumnName("desClaseContrib");
            b.Property(x => x.DesEstado).HasColumnName("desEstado");
            b.Property(x => x.DireccionCorta).HasColumnName("direccionCorta");
            b.Property(x => x.Email).HasColumnName("email");
            b.Property(x => x.NombreComercial).HasColumnName("nombreComercial");
            b.Property(x => x.RazonSocial).HasColumnName("razonSocial");
            b.Property(x => x.TelefonoDomicilio).HasColumnName("telefonoDomicilio");
            b.Property(x => x.TelefonoTrabajo).HasColumnName("telefonoTrabajo");
            b.Property(x => x.CalificacionArtesanal).HasColumnName("calificacionArtesanal");
            b.Property(x => x.DireccionLarga).HasColumnName("direccionLarga");
            b.Property(x => x.Fax).HasColumnName("fax");

            b.Property(x => x.FechaAltaParaEspecial).HasColumnName("fechaAltaParaEspecial");
            b.Property(x => x.FechaCalificacionArtesanal).HasColumnName("fechaCalificacionArtesanal");
            b.Property(x => x.FechaCambioObligado).HasColumnName("fechaCambioObligado");
            b.Property(x => x.FechaInicioActividades).HasColumnName("fechaInicioActividades");
            b.Property(x => x.FechaNacimiento).HasColumnName("fechaNacimiento");
            b.Property(x => x.FechaNotificacionEspeciales).HasColumnName("fechaNotificacionEspeciales");
            b.Property(x => x.FechaUltimaDeclaracion).HasColumnName("fechaUltimaDeclaracion");

            b.Property(x => x.NumeroCalificacionArtesanal).HasColumnName("numeroCalificacionArtesanal");
            b.Property(x => x.ObligadoContabilidad).HasColumnName("obligadoContabilidad");
            b.Property(x => x.ResolucionAltaParaEspecial).HasColumnName("resolucionAltaParaEspecial");
            b.Property(x => x.TipoCalificacionArtesanal).HasColumnName("tipoCalificacionArtesanal");
            b.Property(x => x.UltimoPeriodoFiscalCumplido).HasColumnName("ultimoPeriodoFiscalCumplido");
            b.Property(x => x.NombreAgenteRetencion).HasColumnName("nombreAgenteRetencion");
            b.Property(x => x.EstadoListaBlanca).HasColumnName("estadoListaBlanca");
            b.Property(x => x.MarcaFantasma).HasColumnName("marcaFantasma");

            b.Property(x => x.FechaGrabado)
                .HasColumnName("fecha_grabado")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
