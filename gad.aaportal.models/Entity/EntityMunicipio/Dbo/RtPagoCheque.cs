using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class RtPagoCheque
    {
        public int CodigoPagoCheque { get; set; }
        public int? CodigoDatosIngreso { get; set; }
        public string? NumeroChequePagoCheque { get; set; }
        public string? BancoPagoCheque { get; set; }
        public string? NumeroCuentaPagoCheque { get; set; }
        public string? TelefonoPagoCheque { get; set; }
        public string? EstadoPagoCheque { get; set; }

        public virtual DatosIngreso? CodigoDatosIngresoNavigation { get; set; }
    }
}
