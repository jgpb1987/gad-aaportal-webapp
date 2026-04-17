using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class RteFechaCondonacionDeudum
    {
        public DateTime Fini { get; set; }
        public DateTime? Ffin { get; set; }
        public int? Dias { get; set; }
        public double? Porcentaje { get; set; }
    }
}
