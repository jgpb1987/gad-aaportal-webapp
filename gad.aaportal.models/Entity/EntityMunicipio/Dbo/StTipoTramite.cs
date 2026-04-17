using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class StTipoTramite
    {
        public StTipoTramite()
        {
            StTramites = new HashSet<StTramite>();
        }

        public string TipoTramite { get; set; } = null!;
        public short? Aprobado { get; set; }
        public bool? Externo { get; set; }
        public string? Formulario { get; set; }
        public string? Diagrama { get; set; }
        public string? Descripcion { get; set; }
        public string? TiempoEstimado { get; set; }

        public virtual ICollection<StTramite> StTramites { get; set; }
    }
}
