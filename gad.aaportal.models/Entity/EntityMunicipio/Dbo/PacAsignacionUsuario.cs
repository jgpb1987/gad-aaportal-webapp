using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class PacAsignacionUsuario
    {
        public int IdAsignacionUsuarios { get; set; }
        public int? IdDependecia { get; set; }
        public int? IdUsuario { get; set; }
        public bool? Estado { get; set; }

        public virtual PacDependencia? IdDependeciaNavigation { get; set; }
    }
}
