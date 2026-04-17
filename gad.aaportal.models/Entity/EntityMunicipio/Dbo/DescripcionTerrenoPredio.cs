using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class DescripcionTerrenoPredio
    {
        public string? CodCatastralPredio { get; set; }
        public string? CodTipoDescripcionTerreno { get; set; }

        public virtual Predio? CodCatastralPredioNavigation { get; set; }
        public virtual TipoDescripcionTerreno? CodTipoDescripcionTerrenoNavigation { get; set; }
    }
}
