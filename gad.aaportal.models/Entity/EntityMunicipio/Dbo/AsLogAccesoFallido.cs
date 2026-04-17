using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AsLogAccesoFallido
    {
        public long IdAccesoFallido { get; set; }
        public long IdAcceso { get; set; }
        public string Password { get; set; } = null!;
        public string Tipo { get; set; } = null!;

        public virtual AsLogAccesoSistema IdAccesoNavigation { get; set; } = null!;
    }
}
