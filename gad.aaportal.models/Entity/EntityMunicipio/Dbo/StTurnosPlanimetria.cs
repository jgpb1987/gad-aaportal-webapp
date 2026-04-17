using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class StTurnosPlanimetria
    {
        public int? NumeroDeTramite { get; set; }
        public string? FechaTurno { get; set; }
        public string? HoraTurno { get; set; }
        public string? Descripcion { get; set; }

        public virtual StTramite? NumeroDeTramiteNavigation { get; set; }
    }
}
