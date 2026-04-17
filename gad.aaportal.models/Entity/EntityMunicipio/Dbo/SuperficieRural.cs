using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SuperficieRural
    {
        public int SupRuCodigo { get; set; }
        public decimal? SupRuValorIni { get; set; }
        public decimal? SupRuValorFin { get; set; }
        public decimal? SupRuConstRango { get; set; }
    }
}
