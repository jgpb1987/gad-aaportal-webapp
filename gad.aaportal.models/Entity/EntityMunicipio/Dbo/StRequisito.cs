using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class StRequisito
    {
        public string? TipoTramite { get; set; }
        public string? Requisito { get; set; }

        public virtual StTipoTramite? TipoTramiteNavigation { get; set; }
    }
}
