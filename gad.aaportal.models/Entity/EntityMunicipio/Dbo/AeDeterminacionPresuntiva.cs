using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AeDeterminacionPresuntiva
    {
        public string Ruc { get; set; } = null!;
        public int Anio { get; set; }
        public double? TotalActivo { get; set; }
        public double? TotalPasivo { get; set; }
        public double? PasivoContingente { get; set; }
        public double? TotalPatrimonioNeto { get; set; }
        public double? ImpuestoPatente { get; set; }
        public double? ImpuestoActivosTotales { get; set; }
        public double? RecargoPatente { get; set; }
        public double? RecargoIat { get; set; }
        public string? EstadoDeterminacion { get; set; }

        public virtual AeIdentificacionContribuyente RucNavigation { get; set; } = null!;
    }
}
