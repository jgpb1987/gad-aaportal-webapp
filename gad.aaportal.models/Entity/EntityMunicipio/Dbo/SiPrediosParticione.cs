using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SiPrediosParticione
    {
        public int IdParticion { get; set; }
        public string? CodParticion { get; set; }
        public string? ClaveCatastral { get; set; }
        public double? AvaluoPredio { get; set; }
        public double? AreaPredio { get; set; }
        public string? CiPropietario { get; set; }
        public int? NroTramite { get; set; }
        public double? PorcentajeParticion { get; set; }
        public string? UsuarioIngreso { get; set; }
        public double? AvaluoPorcentaje { get; set; }
        public string? EstadoCalculo { get; set; }
    }
}
