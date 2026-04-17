using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class StPermisoTurismo
    {
        public int NumeroDeTramite { get; set; }
        public string Ruc { get; set; } = null!;
        public string Nlocal { get; set; } = null!;
        public string AnioPermiso { get; set; } = null!;
        public string Ciudadano { get; set; } = null!;
        public string ValorTarifa { get; set; } = null!;
        public string Valor { get; set; } = null!;
        public string? FechaEmision { get; set; }
        public string? AniosRecargo { get; set; }
        public string? MesesRecargoNuevo { get; set; }
        public string? MesesRecargo { get; set; }

        public virtual StTramite NumeroDeTramiteNavigation { get; set; } = null!;
    }
}
