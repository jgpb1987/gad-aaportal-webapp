using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class TipoDestino
    {
        public string CodTipoDestino { get; set; } = null!;
        public string? DescripcionTipoDestino { get; set; }
        public decimal? UsoSuRCoeficiente { get; set; }
        public string? EstadoTipoDestino { get; set; }
    }
}
