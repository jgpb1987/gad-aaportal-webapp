using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VistaReporteMejora
    {
        public string? CodCatastralPredio { get; set; }
        public string? CodigoDeObraAnt { get; set; }
        public string? CuotaAnio { get; set; }
        public double? TotalPagoPorObra { get; set; }
        public double TotalPagados { get; set; }
        public double TotalBajas { get; set; }
        public double TotalNull { get; set; }
        public string? LiquidacionDescuento { get; set; }
    }
}
