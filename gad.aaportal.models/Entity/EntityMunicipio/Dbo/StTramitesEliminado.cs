using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class StTramitesEliminado
    {
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
        public DateTime? FechaEliminacion { get; set; }
    }
}
