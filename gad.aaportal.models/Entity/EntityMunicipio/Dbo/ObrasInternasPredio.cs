using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ObrasInternasPredio
    {
        public string? CodCatastralPredio { get; set; }
        public int? CodObrasConservacion { get; set; }
        public string? CodTipoObrasInternas { get; set; }
        public double? CantidadTipoObrasInternasPredio { get; set; }
        public decimal? ValorObrasInternasPredio { get; set; }
        public decimal? ObInIpAvaluo { get; set; }

        public virtual Predio? CodCatastralPredioNavigation { get; set; }
        public virtual ObrasConservacion? CodObrasConservacionNavigation { get; set; }
        public virtual TipoObrasInterna? CodTipoObrasInternasNavigation { get; set; }
    }
}
