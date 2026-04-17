using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class StRegistroAmbiental
    {
        public int NumeroDeRegistro { get; set; }
        public int NumeroDeTramite { get; set; }
        public string? AnioPermiso { get; set; }
        public string? CodigoCiiu { get; set; }
        public string? Ruc { get; set; }
        public string? Nlocal { get; set; }
        public string? Ciudadano { get; set; }
        public string? NombreDelLocal { get; set; }
        public string? Actividad { get; set; }
        public string? Ejecutado { get; set; }
        public DateTime? FechaProvisional { get; set; }
        public DateTime? FechaDefinitivo { get; set; }
        public DateTime? FechaRenovacion { get; set; }
        public string? NombreAdicionalBeneficiario { get; set; }
        public string? DireccionNegocio { get; set; }
        public string? TipoCertificado { get; set; }

        public virtual StTramite NumeroDeTramiteNavigation { get; set; } = null!;
    }
}
