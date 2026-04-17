using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class DescripcionInversionesPredio
    {
        public string? CodCatastralPredio { get; set; }
        public string? DesEdCodigo { get; set; }
        public decimal? DesInPNumeroArea { get; set; }

        public virtual Predio? CodCatastralPredioNavigation { get; set; }
    }
}
