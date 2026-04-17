using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ObrasConservacion
    {
        public int CodObrasConservacion { get; set; }
        public string? DescripcionObrasConservacion { get; set; }
        public decimal? ConObICoeficiente { get; set; }
        public string? Activo { get; set; }
    }
}
