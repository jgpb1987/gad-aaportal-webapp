using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class DescripcionTerreno
    {
        public DescripcionTerreno()
        {
            TipoDescripcionTerrenos = new HashSet<TipoDescripcionTerreno>();
        }

        public string CodDescripcionTerreno { get; set; } = null!;
        public string? DescripcionDescripcionTerreno { get; set; }
        public string? EstadoDescripcionTerreno { get; set; }
        public string? DesTeTipoPredio { get; set; }

        public virtual ICollection<TipoDescripcionTerreno> TipoDescripcionTerrenos { get; set; }
    }
}
