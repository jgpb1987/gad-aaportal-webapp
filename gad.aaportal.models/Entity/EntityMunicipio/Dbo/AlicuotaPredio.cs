using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AlicuotaPredio
    {
        public string? CodCatastralPredio { get; set; }
        public double? TerrenoPublico { get; set; }
        public double? TerrenoPrivado { get; set; }
        public double? ConstruccionPublico { get; set; }
        public double? ConstruccionPrivado { get; set; }
        public decimal? AliPrGeneral { get; set; }
        public int? NroBloque { get; set; }

        public virtual Predio? CodCatastralPredioNavigation { get; set; }
    }
}
