using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class RteTipoEspectaculo
    {
        public RteTipoEspectaculo()
        {
            RteDescripcionEspectaculos = new HashSet<RteDescripcionEspectaculo>();
            RteEspectaculosPublicos = new HashSet<RteEspectaculosPublico>();
        }

        public int CodigoTipoEspectaculo { get; set; }
        public string CodigoEspectaculo { get; set; } = null!;
        public string? DescripcionTipoEspectaculo { get; set; }
        public short? TarifaTipoEspectaculo { get; set; }
        public string? EstadoTitulo { get; set; }

        public virtual ICollection<RteDescripcionEspectaculo> RteDescripcionEspectaculos { get; set; }
        public virtual ICollection<RteEspectaculosPublico> RteEspectaculosPublicos { get; set; }
    }
}
