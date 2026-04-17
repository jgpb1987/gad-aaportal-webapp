using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class RteDescripcionEspectaculo
    {
        public int CodigoDescripcionEspectaculos { get; set; }
        public string? TipoEspectaculo { get; set; }
        public string? Localidad { get; set; }
        public string? Estado { get; set; }

        public virtual RteTipoEspectaculo? TipoEspectaculoNavigation { get; set; }
    }
}
