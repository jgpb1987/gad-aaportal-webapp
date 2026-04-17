using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VistaValorPorMetroRural
    {
        public string? CodCatastralPredio { get; set; }
        public int? CodClaseTierra { get; set; }
        public string? CodTipoDestino { get; set; }
        public decimal? SuperficieTerreno { get; set; }
        public decimal? ValApRValorTerreno { get; set; }
    }
}
