using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class TipoDescripcionTerreno
    {
        public string CodTipoDescripcionTerreno { get; set; } = null!;
        public string? DescripcionTipoDescripcionTerreno { get; set; }
        public decimal? CoeficienteTipoDescripcionTerreno { get; set; }
        public string? EstadoTipoDescripcionTerreno { get; set; }
        public string? DesTeCodigoFicha { get; set; }
        public string? DesTeTipoPredio { get; set; }
        public string? CodDescripcionTerreno { get; set; }

        public virtual DescripcionTerreno? CodDescripcionTerrenoNavigation { get; set; }
    }
}
