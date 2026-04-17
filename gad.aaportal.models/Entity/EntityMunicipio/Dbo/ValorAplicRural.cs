using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ValorAplicRural
    {
        public int? ClaTiCodigo { get; set; }
        public int? SupRuCodigo { get; set; }
        public decimal? ValApRValorTerreno { get; set; }

        public virtual ClaseTierra? ClaTiCodigoNavigation { get; set; }
        public virtual SuperficieRural? SupRuCodigoNavigation { get; set; }
    }
}
