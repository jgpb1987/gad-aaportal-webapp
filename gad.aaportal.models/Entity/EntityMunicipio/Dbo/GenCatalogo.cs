using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class GenCatalogo
    {
        public int CatCodigo { get; set; }
        public int TabCodigo { get; set; }
        public string CatConcepto { get; set; } = null!;
        public string CatEstado { get; set; } = null!;
        public string CatValor { get; set; } = null!;

        public virtual GenTabla TabCodigoNavigation { get; set; } = null!;
    }
}
