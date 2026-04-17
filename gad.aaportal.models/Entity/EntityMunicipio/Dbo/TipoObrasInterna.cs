using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class TipoObrasInterna
    {
        public string CodTipoObrasInternas { get; set; } = null!;
        public string? DescripcionTipoObrasInternas { get; set; }
        public string? EstadoTipoObrasInternas { get; set; }
        public string? UnidadTipoObrasInternas { get; set; }
        public decimal? ValorTipoObrasInternas { get; set; }
        public string? CodObrasInternas { get; set; }

        public virtual ObrasInterna? CodObrasInternasNavigation { get; set; }
    }
}
