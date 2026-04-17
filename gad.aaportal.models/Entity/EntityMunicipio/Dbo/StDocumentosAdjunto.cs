using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class StDocumentosAdjunto
    {
        public int? NumeroDeTramite { get; set; }
        public int? Secuencia { get; set; }
        public string? NombreDelDocumentoAdjunto { get; set; }

        public virtual StMensaje? StMensaje { get; set; }
    }
}
