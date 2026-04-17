using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SiTipoImpuesto
    {
        public int IdTipoImpuesto { get; set; }
        public string? TipoImpuesto { get; set; }
        public string? EstadoTipo { get; set; }
        public string? Predio { get; set; }
    }
}
