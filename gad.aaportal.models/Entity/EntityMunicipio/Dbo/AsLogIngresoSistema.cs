using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AsLogIngresoSistema
    {
        public long IdIngreso { get; set; }
        public long IdLogAcceso { get; set; }
        public int IdSistema { get; set; }
        public DateTime FechaHora { get; set; }

        public virtual AsLogAccesoSistema IdLogAccesoNavigation { get; set; } = null!;
    }
}
