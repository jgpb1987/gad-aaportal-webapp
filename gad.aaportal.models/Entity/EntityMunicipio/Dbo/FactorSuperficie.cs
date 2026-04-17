using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class FactorSuperficie
    {
        public int? ZonHoCodigo { get; set; }
        public int? SupRuCodigo { get; set; }
        public decimal? FacSuFactor { get; set; }

        public virtual SuperficieRural? SupRuCodigoNavigation { get; set; }
        public virtual Influencia? ZonHoCodigoNavigation { get; set; }
    }
}
