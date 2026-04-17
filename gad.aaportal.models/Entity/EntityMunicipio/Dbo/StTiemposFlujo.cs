using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class StTiemposFlujo
    {
        public string? TipoTramite { get; set; }
        public int? Secuencia { get; set; }
        public int? TiempoVerde { get; set; }
        public int? TiempoAmarillo { get; set; }

        public virtual StTipoTramite? TipoTramiteNavigation { get; set; }
    }
}
