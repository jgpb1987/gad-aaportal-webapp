using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SaLiteralesArticulo
    {
        public int IdLiteral { get; set; }
        public int? IdArticulo { get; set; }
        public string? Texto { get; set; }

        public virtual SaArticulosOrdenanza? IdArticuloNavigation { get; set; }
    }
}
