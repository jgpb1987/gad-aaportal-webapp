using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SaCumplimientolineamiento
    {
        public int IdCumpliemiento { get; set; }
        public string? Observacion { get; set; }
        public int? IdLineamiento { get; set; }
        public int? IdLocal { get; set; }
    }
}
