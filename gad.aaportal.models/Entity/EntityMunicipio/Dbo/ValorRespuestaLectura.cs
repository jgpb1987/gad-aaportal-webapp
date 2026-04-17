using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ValorRespuestaLectura
    {
        public int? CodigoIngreso { get; set; }
        public string? CodigoConcepto { get; set; }
        public double? ValorConcepto { get; set; }
    }
}
