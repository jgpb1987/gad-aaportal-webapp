using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class PacTipoCuentaContable
    {
        public PacTipoCuentaContable()
        {
            PacDependencia = new HashSet<PacDependencia>();
            PacSubGrupoCuentasContables = new HashSet<PacSubGrupoCuentasContable>();
        }

        public int IdTipoCuentaContable { get; set; }
        public string? TipoCuentaContable { get; set; }

        public virtual ICollection<PacDependencia> PacDependencia { get; set; }
        public virtual ICollection<PacSubGrupoCuentasContable> PacSubGrupoCuentasContables { get; set; }
    }
}
