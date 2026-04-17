using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class MenPerfilMenu
    {
        public int PmeId { get; set; }
        public int PerIdPerfil { get; set; }
        public int MenIdmenu { get; set; }
        public string PmeEstado { get; set; } = null!;
        public DateTime PmeFecCreacion { get; set; }
        public string PmeUsuMod { get; set; } = null!;

        public virtual MenMenu MenIdmenuNavigation { get; set; } = null!;
        public virtual MenPerfil PerIdPerfilNavigation { get; set; } = null!;
    }
}
