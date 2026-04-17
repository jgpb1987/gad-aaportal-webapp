using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ConservCultivo
    {
        public string TipCuCodigo { get; set; } = null!;
        public string ConCuTipo { get; set; } = null!;
        public decimal? ConCuValor { get; set; }
    }
}
