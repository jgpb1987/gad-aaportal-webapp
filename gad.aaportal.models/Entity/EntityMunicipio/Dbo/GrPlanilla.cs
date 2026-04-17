using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class GrPlanilla
    {
        public int CodigoPlanilla { get; set; }
        public int? CodEnlacePlanilla { get; set; }
        public string? NumeroPlanilla { get; set; }
        public DateTime? FechaPagoPlanilla { get; set; }
        public string? NumeroChequePlanilla { get; set; }
        public double? ValorPlanilla { get; set; }
        public string? DetallePlanilla { get; set; }
    }
}
