using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SiInteresReferencial
    {
        public int IdInteres { get; set; }
        public double? PorcentajeReferencial { get; set; }
        public int? Mes { get; set; }
        public int? Anio { get; set; }
    }
}
