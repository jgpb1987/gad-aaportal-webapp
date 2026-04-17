using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ValoresTributario
    {
        public string? Descrip { get; set; }
        public DateTime? FechaPago { get; set; }
        public DateTime FechaIngreso { get; set; }
        public double? Valores { get; set; }
    }
}
