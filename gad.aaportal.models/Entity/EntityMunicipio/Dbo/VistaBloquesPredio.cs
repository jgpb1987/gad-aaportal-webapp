using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VistaBloquesPredio
    {
        public decimal? Superficie { get; set; }
        public string CodCatastralPredio { get; set; } = null!;
    }
}
