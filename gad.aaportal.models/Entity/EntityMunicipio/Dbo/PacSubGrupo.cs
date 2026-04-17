using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class PacSubGrupo
    {
        public PacSubGrupo()
        {
            PacProductos = new HashSet<PacProducto>();
            PacSubGrupoCuentasContables = new HashSet<PacSubGrupoCuentasContable>();
            PacTechoPresupuestarios = new HashSet<PacTechoPresupuestario>();
        }

        public int IdSubGrupo { get; set; }
        public int IdGrupo { get; set; }
        public string NombreSubGrupo { get; set; } = null!;
        public string CuentaContableSubGrupo { get; set; } = null!;

        public virtual PacGrupo IdGrupoNavigation { get; set; } = null!;
        public virtual ICollection<PacProducto> PacProductos { get; set; }
        public virtual ICollection<PacSubGrupoCuentasContable> PacSubGrupoCuentasContables { get; set; }
        public virtual ICollection<PacTechoPresupuestario> PacTechoPresupuestarios { get; set; }
    }
}
