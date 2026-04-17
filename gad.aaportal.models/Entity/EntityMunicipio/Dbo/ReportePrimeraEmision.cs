using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ReportePrimeraEmision
    {
        public string CodClienteIngreso { get; set; } = null!;
        public string? ClaveCatastral { get; set; }
        public string CodTituloDatos { get; set; } = null!;
        public double ValorTitulo { get; set; }
        public decimal? ValPrValTotalTerrPredio { get; set; }
        public decimal? ValPrValTotalEdifPredio { get; set; }
        public double? AvaluoComercial { get; set; }
        public double? BaseImponible { get; set; }
        public double? Impuesto { get; set; }
        public double? ContribPredialCuerpoBomberos { get; set; }
        public double? SolarNoEdificado { get; set; }
        public double? Tasa { get; set; }
    }
}
