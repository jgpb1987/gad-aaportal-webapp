using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class RteLiquidacion
    {
        public int CodProyecto { get; set; }
        public string? Memo { get; set; }
        public DateTime? FechaLiquidacion { get; set; }
        public double? ValorLiquidacion { get; set; }
        public string? Memorando { get; set; }
        public string? Tramite { get; set; }
        public string? JefeRentas { get; set; }
        public string? Tesorero { get; set; }
    }
}
