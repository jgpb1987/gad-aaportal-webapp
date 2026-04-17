using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VistaReemplazoPeritaje
    {
        public string? CodCatastralPredio { get; set; }
        public double? ValorPeritaje { get; set; }
        public double? ValorTerreno { get; set; }
        public double? ValorEdificacion { get; set; }
        public decimal? ValorValoracion { get; set; }
        public decimal? ValPrValTotalTerrPredio { get; set; }
        public decimal? ValPrValTotalEdifPredio { get; set; }
        public string? TipoPredio { get; set; }
        public DateTime? FechaPeritaje { get; set; }
    }
}
