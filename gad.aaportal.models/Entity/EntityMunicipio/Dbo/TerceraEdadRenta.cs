using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class TerceraEdadRenta
    {
        public string Ruc { get; set; } = null!;
        public string? RazonSocial { get; set; }
        public double? TotalIngresos { get; set; }
        public double? TotActCorriente410 { get; set; }
        public double? _812totActivoNoCorriente { get; set; }
        public double? TotPasivoCorriente1030 { get; set; }
        public double? TotPasivoLargoPlazo1250 { get; set; }
        public double? TotalPasivo1310 { get; set; }
        public double? TotPasivoPatrimonio1340 { get; set; }
    }
}
