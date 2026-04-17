using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AsMaquina
    {
        public AsMaquina()
        {
            AsLogAccesoSistemas = new HashSet<AsLogAccesoSistema>();
        }

        public string IpMaquina { get; set; } = null!;
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<AsLogAccesoSistema> AsLogAccesoSistemas { get; set; }
    }
}
