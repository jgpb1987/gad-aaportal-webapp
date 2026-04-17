using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VistaDesgloseEmisionRural
    {
        public int CodIngreso { get; set; }
        public string? ClaveCatastral { get; set; }
        public double? AvaluoCatastral { get; set; }
        public double? ImpuestoALosPrediosRusticos { get; set; }
        public double? ContribPredialCuerpoBomberos { get; set; }
        public double? Tasa { get; set; }
        public double? EspecieValorada { get; set; }
    }
}
