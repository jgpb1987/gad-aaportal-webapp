using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VistaTramitesAprobadosPlanificacion
    {
        public string? TipoTramite { get; set; }
        public int NumeroDeTramite { get; set; }
        public string? Beneficiario { get; set; }
        public DateTime? FechaDeIngreso { get; set; }
        public string? UsuarioIngresoTramite { get; set; }
        public string? UsuarioEnvioArentas { get; set; }
        public DateTime? FechaEnvioArentas { get; set; }
        public int? NroDias { get; set; }
    }
}
