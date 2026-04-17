using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class RangoImpuestoPatente
    {
        public int CodRango { get; set; }
        public double? Inferior { get; set; }
        public double? Superior { get; set; }
        public double? Impuesto { get; set; }
        public double? Excedente { get; set; }
    }
}
