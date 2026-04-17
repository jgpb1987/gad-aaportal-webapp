using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VistaParaCertificacionAvaluo
    {
        public string? Nombres { get; set; }
        public string? CiuCedula { get; set; }
        public DateTime FechaActual { get; set; }
        public decimal? AreaTotalPredio { get; set; }
        public string? CodigoRuralUrbano { get; set; }
        public string? Parroquia { get; set; }
        public string CodCatastralPredio { get; set; } = null!;
        public decimal? PreBaValor { get; set; }
        public string? CodTipoDescripcionTerreno { get; set; }
        public string Tipodepredio { get; set; } = null!;
        public decimal? Valorpormetrocuadrado { get; set; }
        public decimal? ValPrValComerPredio { get; set; }
        public decimal? ValPrValTotalEdifPredio { get; set; }
        public decimal? ValPrValTotalTerrPredio { get; set; }
        public decimal? ValApRValorTerreno { get; set; }
    }
}
