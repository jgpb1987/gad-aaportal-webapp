using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ApTrabjadoresAsignado
    {
        public int CodIngreso { get; set; }
        public string? CedulaTrabajador { get; set; }

        public virtual ApServicioAlCliente CodIngresoNavigation { get; set; } = null!;
    }
}
