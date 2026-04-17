using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class StSecuenciaDelFlujo
    {
        public int IdSecuenciaDelFlujo { get; set; }
        public string TipoTramite { get; set; } = null!;
        public string De { get; set; } = null!;
        public string Para { get; set; } = null!;
        public string SecuenciaDelFlujo { get; set; } = null!;
        public string SecuenciaDelFlujoAnterior { get; set; } = null!;
        public string SecuenciaFinal { get; set; } = null!;

        public virtual StTipoTramite TipoTramiteNavigation { get; set; } = null!;
    }
}
