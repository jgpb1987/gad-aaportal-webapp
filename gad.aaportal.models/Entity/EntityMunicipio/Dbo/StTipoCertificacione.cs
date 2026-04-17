using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class StTipoCertificacione
    {
        public StTipoCertificacione()
        {
            StCertificaciones = new HashSet<StCertificacione>();
        }

        public string Tipocertificacion { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string? Areas { get; set; }
        public string? M2 { get; set; }
        public string? Activo { get; set; }

        public virtual ICollection<StCertificacione> StCertificaciones { get; set; }
    }
}
