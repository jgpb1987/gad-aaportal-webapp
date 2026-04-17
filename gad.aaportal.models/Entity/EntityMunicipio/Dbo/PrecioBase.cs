using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class PrecioBase
    {
        public int PreBaCodigo { get; set; }
        public string? PreBaCodZona { get; set; }
        public string? PreBaCodSect { get; set; }
        public string? PreBaCodMz { get; set; }
        public string? PreBaCodDesde { get; set; }
        public string? PreBaCodHasta { get; set; }
        public decimal? PreBaValor { get; set; }
        public string? DivPoCodigo { get; set; }

        public virtual DivPol? DivPoCodigoNavigation { get; set; }
    }
}
