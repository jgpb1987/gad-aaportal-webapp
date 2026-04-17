using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class RteNotifActaMese
    {
        public int CodActaMeses { get; set; }
        public int? CodNotifActaCompromiso { get; set; }
        public DateTime? FechaMensualidades { get; set; }
        public string? EstadoActaMeses { get; set; }
    }
}
