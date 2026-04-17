using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class PacDependencia
    {
        public PacDependencia()
        {
            PacAsignacionUsuarios = new HashSet<PacAsignacionUsuario>();
            PacCompras = new HashSet<PacCompra>();
        }

        public int IdDependencia { get; set; }
        public string? Dependencia { get; set; }
        public bool? Estado { get; set; }
        public int? IdTipoCuentaContable { get; set; }

        public virtual PacTipoCuentaContable? IdTipoCuentaContableNavigation { get; set; }
        public virtual ICollection<PacAsignacionUsuario> PacAsignacionUsuarios { get; set; }
        public virtual ICollection<PacCompra> PacCompras { get; set; }
    }
}
