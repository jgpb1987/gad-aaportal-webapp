using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class TerrenoRuralPredio
    {
        public string? CodCatastralPredio { get; set; }
        public int? CodClaseTierra { get; set; }
        public string? CodTipoDestino { get; set; }
        public decimal? SuperficieTerreno { get; set; }
        public decimal? ValorUnitarioHectareaTerreno { get; set; }
        public decimal? ValorTerreno { get; set; }

        public virtual Predio? CodCatastralPredioNavigation { get; set; }
        public virtual ClaseTierra? CodClaseTierraNavigation { get; set; }
        public virtual TipoDestino? CodTipoDestinoNavigation { get; set; }
    }
}
