using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ParametrosDeterminacionPredio
    {
        public string CodCatastral { get; set; } = null!;
        public string? Anio { get; set; }
        public int? LeyAnciano { get; set; }
        public int? LeyAnciano50 { get; set; }
        public int? CultoTemploPrivado { get; set; }
        public int? PrestamoHipotecario { get; set; }
        public int? Turismo { get; set; }
        public int? Artesano { get; set; }
        public int? Minusvalido { get; set; }
        public int? Patrimonio { get; set; }
        public int? RecargoSolar { get; set; }
        public int? ImpuestoSolar { get; set; }
        public int? Construccion { get; set; }
        public int? Ptm { get; set; }
        public int? Tagr { get; set; }
        public int? Riesg { get; set; }
        public int? Des { get; set; }
        public string? Usuario { get; set; }

        public virtual Predio CodCatastralNavigation { get; set; } = null!;
    }
}
