using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AccionesDePredio
    {
        public string CodCatastralPredio { get; set; } = null!;
        public string CedIdentCiudadano { get; set; } = null!;
        public double? Porcentaje { get; set; }
        public string? Usuario { get; set; }
        public int? CodIngresoRentas { get; set; }

        public virtual Ciudadano CedIdentCiudadanoNavigation { get; set; } = null!;
    }
}
