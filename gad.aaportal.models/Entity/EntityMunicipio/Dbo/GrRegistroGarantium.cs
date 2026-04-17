using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class GrRegistroGarantium
    {
        public int CodigoRegistroGarantia { get; set; }
        public int? CodigoEnlaceRegistroGarantia { get; set; }
        public string? TipoRegistroGarantia { get; set; }
        public string? DescripcionRegistroGarantia { get; set; }
        public double? ValorRegistroGarantia { get; set; }
        public DateTime? FechaVencimientoRegistroGarantia { get; set; }
        public string? EstadoRegistroGarantia { get; set; }
        public DateTime? FechaPago { get; set; }
        public string? Observacion { get; set; }
    }
}
