using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class NcObservacionesImpresion
    {
        public int IdObs { get; set; }
        public string? Motivo { get; set; }
        public string? UsuarioIngreso { get; set; }
        public int? CodNc { get; set; }

        public virtual NcNotaCredito? CodNcNavigation { get; set; }
    }
}
