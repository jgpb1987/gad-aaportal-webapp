using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class MenMenu
    {
        public MenMenu()
        {
            MenPerfilMenus = new HashSet<MenPerfilMenu>();
        }

        public int MenIdmenu { get; set; }
        public string? MenNombre { get; set; }
        public string? MenNombreusercontrol { get; set; }
        public string? MenNombrexap { get; set; }
        public int? MenIdmenupadre { get; set; }
        public int? MenOrden { get; set; }
        public int? MenNivel { get; set; }
        public string MenHijos { get; set; } = null!;
        public string? MenEstado { get; set; }

        public virtual ICollection<MenPerfilMenu> MenPerfilMenus { get; set; }
    }
}
