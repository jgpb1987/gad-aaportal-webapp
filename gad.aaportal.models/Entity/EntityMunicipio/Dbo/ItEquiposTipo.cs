using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ItEquiposTipo
    {
        public ItEquiposTipo()
        {
            ItEquipos = new HashSet<ItEquipo>();
        }

        public string TipoEquipo { get; set; } = null!;

        public virtual ICollection<ItEquipo> ItEquipos { get; set; }
    }
}
