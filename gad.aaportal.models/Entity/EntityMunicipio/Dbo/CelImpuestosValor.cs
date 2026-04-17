using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class CelImpuestosValor
    {
        public string Codigo { get; set; } = null!;
        public string ImpuestoCodigo { get; set; } = null!;
        public double Porcentaje { get; set; }
        public string Descripcion { get; set; } = null!;
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
    }
}
