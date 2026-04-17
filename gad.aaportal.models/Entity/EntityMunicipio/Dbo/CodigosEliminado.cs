using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class CodigosEliminado
    {
        public string? CedIdentCiudadano { get; set; }
        public string? Codigo { get; set; }
        public string? NombreTabla { get; set; }
        public int? NroLocal { get; set; }

        public virtual CiudadanosEliminado? CedIdentCiudadanoNavigation { get; set; }
    }
}
