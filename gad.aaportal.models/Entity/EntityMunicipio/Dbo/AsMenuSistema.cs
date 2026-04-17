using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AsMenuSistema
    {
        public AsMenuSistema()
        {
            AsItemMenus = new HashSet<AsItemMenu>();
            AsPermisos = new HashSet<AsPermiso>();
        }

        public int IdMenu { get; set; }
        public string Titulo { get; set; } = null!;
        public int IdSistema { get; set; }

        public virtual AsSistema IdSistemaNavigation { get; set; } = null!;
        public virtual ICollection<AsItemMenu> AsItemMenus { get; set; }
        public virtual ICollection<AsPermiso> AsPermisos { get; set; }
    }
}
