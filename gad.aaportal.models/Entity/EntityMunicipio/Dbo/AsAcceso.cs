using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AsAcceso
    {
        public AsAcceso()
        {
            AsPermisos = new HashSet<AsPermiso>();
        }

        public int IdAcceso { get; set; }
        public int IdSistema { get; set; }
        public int IdUsuario { get; set; }
        public string? Descripcion { get; set; }

        public virtual AsSistema IdSistemaNavigation { get; set; } = null!;
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<AsPermiso> AsPermisos { get; set; }
    }
}
