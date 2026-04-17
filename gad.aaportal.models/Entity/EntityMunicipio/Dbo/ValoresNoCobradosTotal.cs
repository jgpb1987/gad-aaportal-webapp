using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ValoresNoCobradosTotal
    {
        public double? N { get; set; }
        public string Cedula { get; set; } = null!;
        public string? Nombres { get; set; }
        public double? Adeuda { get; set; }
        public int? CodIngresoArentas { get; set; }
    }
}
