using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SmFormula
    {
        public int IdFormula { get; set; }
        public string? Descripcion { get; set; }
        public string? Articulo { get; set; }
        public string? Formula { get; set; }
        public int? IdTipoMejora { get; set; }

        public virtual SmTipoMejora? IdTipoMejoraNavigation { get; set; }
    }
}
