using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class StCopia
    {
        public int? NumeroDeTramite { get; set; }
        public int? Secuencia { get; set; }
        public int? NumeroDeTramiteHijo { get; set; }
        public string? Para { get; set; }
        public string? Copia { get; set; }

        public virtual StMensaje? StMensaje { get; set; }
    }
}
