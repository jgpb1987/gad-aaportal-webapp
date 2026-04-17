using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class NcObservacione
    {
        public int IdObservaciones { get; set; }
        public string? Observaciones { get; set; }
        public string? Usuario { get; set; }
        public int? IdNotaCredito { get; set; }

        public virtual NcNotaCredito? IdNotaCreditoNavigation { get; set; }
    }
}
