using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class PredioColindante
    {
        public string CodCatastralPredio { get; set; } = null!;
        public string? CiuCedula { get; set; }
        public string? Nombre { get; set; }
        public string? Este { get; set; }
        public string? Norte { get; set; }
        public string? Oeste { get; set; }
        public string? Sur { get; set; }
    }
}
