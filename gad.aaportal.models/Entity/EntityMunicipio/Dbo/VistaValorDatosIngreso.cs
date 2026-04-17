using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VistaValorDatosIngreso
    {
        public int CodIngreso { get; set; }
        public double? Valor { get; set; }
        public string? DescripcionDescripcion { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string CodTituloDatos { get; set; } = null!;
        public string? ClaveCatastral { get; set; }
        public double? AvaluoCatastral { get; set; }
    }
}
