using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class StVariosTrabajo
    {
        public int NumeroDeTramite { get; set; }
        public string? Interseccion { get; set; }
        public string? AreaConstruccion { get; set; }
        public string? AvaluoConstruccion { get; set; }
        public string? InformesAutorizacion { get; set; }
        public string? InformesAdicionales { get; set; }
        public string? NumeroDeLotes { get; set; }
        public string? AvaluoTotalConstruccion { get; set; }
        public DateTime? FechaDeImpresion { get; set; }

        public virtual StTramite NumeroDeTramiteNavigation { get; set; } = null!;
    }
}
