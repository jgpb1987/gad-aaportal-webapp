namespace gad.aaportal.models.Entity.Dinardap
{
    public class SriContribuyenteDatos
    {
        public string NumeroRuc { get; set; }

        public string CodClaseContrib { get; set; }
        public string CodEstado { get; set; }
        public string DesClaseContrib { get; set; }
        public string DesEstado { get; set; }
        public string DireccionCorta { get; set; }
        public string Email { get; set; }
        public string NombreComercial { get; set; }
        public string RazonSocial { get; set; }
        public string TelefonoDomicilio { get; set; }
        public string TelefonoTrabajo { get; set; }
        public string CalificacionArtesanal { get; set; }
        public string DireccionLarga { get; set; }
        public string Fax { get; set; }

        public DateTime? FechaAltaParaEspecial { get; set; }
        public DateTime? FechaCalificacionArtesanal { get; set; }
        public DateTime? FechaCambioObligado { get; set; }
        public DateTime? FechaInicioActividades { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public DateTime? FechaNotificacionEspeciales { get; set; }
        public DateTime? FechaUltimaDeclaracion { get; set; }

        public string NumeroCalificacionArtesanal { get; set; }
        public string ObligadoContabilidad { get; set; }
        public string ResolucionAltaParaEspecial { get; set; }
        public string TipoCalificacionArtesanal { get; set; }
        public string UltimoPeriodoFiscalCumplido { get; set; }
        public string NombreAgenteRetencion { get; set; }
        public string EstadoListaBlanca { get; set; }
        public string MarcaFantasma { get; set; }

        public DateTime FechaGrabado { get; set; }
    }
}
