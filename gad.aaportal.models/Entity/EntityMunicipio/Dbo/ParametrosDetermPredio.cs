using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ParametrosDetermPredio
    {
        public string? PreCodigoCatastral { get; set; }
        public string? ParDeCodigo { get; set; }
        public decimal? ParDePValor { get; set; }
        public DateTime? ParDePFecha { get; set; }
    }
}
