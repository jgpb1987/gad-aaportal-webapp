using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class StRequisitosTramite
    {
        public int NumeroDeTramite { get; set; }
        public string? Requisito { get; set; }
        public string? Verificacion { get; set; }

        public virtual StTramite NumeroDeTramiteNavigation { get; set; } = null!;
    }
}
