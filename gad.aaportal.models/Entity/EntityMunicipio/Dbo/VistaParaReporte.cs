using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VistaParaReporte
    {
        public string Ruc { get; set; } = null!;
        public string? RazonSocial { get; set; }
        public double? IngresosTotales { get; set; }
        public double? Patrimonio { get; set; }
        public double? IpatenteMensualAnualizada { get; set; }
        public double? TotalActivos { get; set; }
        public double? PasivoCorriente { get; set; }
        public double? Contingencias { get; set; }
        public DateTime? FechaEmicion { get; set; }
        public string? Personeria { get; set; }
        public string? ClaveCatastralPredio { get; set; }
        public byte EnActividad { get; set; }
    }
}
