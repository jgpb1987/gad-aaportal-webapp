using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class JustificantesMinusvalido
    {
        public string? CodCatastral { get; set; }
        public string? NroTramiteMinusvalido { get; set; }
        public string? NroConadisMinusvalido { get; set; }

        public virtual Predio? CodCatastralNavigation { get; set; }
    }
}
