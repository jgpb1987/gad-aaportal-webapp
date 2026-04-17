using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class RtTipoPago
    {
        public string CodigoRtTipoPago { get; set; } = null!;
        public string? DescripcionRtTipoPago { get; set; }
        public string? EstadoRtTipoPago { get; set; }
    }
}
