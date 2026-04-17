using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class RteCondonacionDeuda
    {
        public int CodCondenacion { get; set; }
        public int? CodIngreso { get; set; }
        public double? Interes { get; set; }
        public double? Recargo { get; set; }
        public int? Porcentaje { get; set; }
        public string? Estado { get; set; }
        public DateTime? FEcha { get; set; }
    }
}
