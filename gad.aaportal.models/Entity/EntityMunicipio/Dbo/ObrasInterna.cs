using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ObrasInterna
    {
        public ObrasInterna()
        {
            TipoObrasInternas = new HashSet<TipoObrasInterna>();
        }

        public string CodObrasInternas { get; set; } = null!;
        public string? DescripcionObrasInternas { get; set; }
        public string? EstadoObrasInternas { get; set; }
        public string? TipObIUnidad { get; set; }

        public virtual ICollection<TipoObrasInterna> TipoObrasInternas { get; set; }
    }
}
