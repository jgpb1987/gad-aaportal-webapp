using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class StAreasDeTrabajoTipoDeTramite
    {
        public string? CodigoAreaDeTrabajo { get; set; }
        public string? TipoTramite { get; set; }

        public virtual AreaTrabajo? CodigoAreaDeTrabajoNavigation { get; set; }
        public virtual StTipoTramite? TipoTramiteNavigation { get; set; }
    }
}
