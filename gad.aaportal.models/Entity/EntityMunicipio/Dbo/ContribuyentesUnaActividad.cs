using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ContribuyentesUnaActividad
    {
        public string Ruc { get; set; } = null!;
        public int? IdPersoneria { get; set; }
        public string? Contabilidad { get; set; }
        public string? Rise { get; set; }
    }
}
