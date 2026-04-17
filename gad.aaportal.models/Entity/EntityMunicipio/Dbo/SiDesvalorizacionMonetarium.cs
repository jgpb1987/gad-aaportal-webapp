using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SiDesvalorizacionMonetarium
    {
        public int IdDesvalorizacion { get; set; }
        public int? Anio { get; set; }
        public double? Porcentaje { get; set; }
    }
}
