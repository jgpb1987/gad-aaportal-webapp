using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class StTramite
    {
        public StTramite()
        {
            StCertificaciones = new HashSet<StCertificacione>();
            StMensajes = new HashSet<StMensaje>();
            StQuejasSugerencia = new HashSet<StQuejasSugerencia>();
            StRegistroAmbientalNoAutomatizados = new HashSet<StRegistroAmbientalNoAutomatizado>();
        }

        public string? TipoTramite { get; set; }
        public int NumeroDeTramite { get; set; }
        public string? NumeroDeQuipux { get; set; }
        public string? Asunto { get; set; }
        public string? Externo { get; set; }
        public short? Grabado { get; set; }
        public int? TotalHojas { get; set; }
        public string? Observaciones { get; set; }
        public string? NombreAdicional { get; set; }
        public string? PredioClave { get; set; }
        public string? Valor { get; set; }
        public string? Referencia { get; set; }
        public int? TramitePadre { get; set; }
        public DateTime? ConcluidoFecha { get; set; }
        public string? SecuenciaDelFlujo { get; set; }
        public string? Aprobado { get; set; }
        public string? AreaFraccionamiento { get; set; }
        public string? NumeroLotes { get; set; }
        public string? CerramientoProvisional { get; set; }
        public string? AprobadoJefeRentas { get; set; }
        public string? TipoCertificado { get; set; }
        public string? ObservacionesRequisitos { get; set; }
        public string? UsuarioConcluido { get; set; }
        public string? SecuenciaDelFlujoConcluido { get; set; }
        public string? EstadoTramite { get; set; }

        public virtual StTipoTramite? TipoTramiteNavigation { get; set; }
        public virtual StAlquilerCanchaFutbol? StAlquilerCanchaFutbol { get; set; }
        public virtual StRegistroAmbiental? StRegistroAmbiental { get; set; }
        public virtual StRegulacionUrbana? StRegulacionUrbana { get; set; }
        public virtual StRegulacionUrbanaServicio? StRegulacionUrbanaServicio { get; set; }
        public virtual StTramitesComisarium? StTramitesComisarium { get; set; }
        public virtual StTramitesPlanificacion? StTramitesPlanificacion { get; set; }
        public virtual StTramitesServiciosPublico? StTramitesServiciosPublico { get; set; }
        public virtual StVariosTrabajo? StVariosTrabajo { get; set; }
        public virtual ICollection<StCertificacione> StCertificaciones { get; set; }
        public virtual ICollection<StMensaje> StMensajes { get; set; }
        public virtual ICollection<StQuejasSugerencia> StQuejasSugerencia { get; set; }
        public virtual ICollection<StRegistroAmbientalNoAutomatizado> StRegistroAmbientalNoAutomatizados { get; set; }
    }
}
