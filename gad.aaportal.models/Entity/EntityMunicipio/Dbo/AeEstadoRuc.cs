using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AeEstadoRuc
    {
        public AeEstadoRuc()
        {
            AeIdentificacionContribuyentes = new HashSet<AeIdentificacionContribuyente>();
            AeMovimientoRucs = new HashSet<AeMovimientoRuc>();
        }

        public string IdEstado { get; set; } = null!;
        public string? Estado { get; set; }

        public virtual ICollection<AeIdentificacionContribuyente> AeIdentificacionContribuyentes { get; set; }
        public virtual ICollection<AeMovimientoRuc> AeMovimientoRucs { get; set; }
    }
}
