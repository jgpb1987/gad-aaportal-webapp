using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AsPermiso
    {
        public int IdPermiso { get; set; }
        public int IdAcceso { get; set; }
        public int IdMenu { get; set; }
        public string Valor { get; set; } = null!;

        public virtual AsAcceso IdAccesoNavigation { get; set; } = null!;
        public virtual AsMenuSistema IdMenuNavigation { get; set; } = null!;
    }
}
