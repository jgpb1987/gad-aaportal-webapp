using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class PacSubGrupoCuentasContable
    {
        public int IdPacSubCuentas { get; set; }
        public int? IdTipoCuentaContable { get; set; }
        public string? CuentaContableSubGrupo { get; set; }
        public int? IdSubGrupo { get; set; }
        public bool? Estado { get; set; }

        public virtual PacSubGrupo? IdSubGrupoNavigation { get; set; }
        public virtual PacTipoCuentaContable? IdTipoCuentaContableNavigation { get; set; }
    }
}
