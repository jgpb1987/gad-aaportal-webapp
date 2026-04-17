using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SiParametro
    {
        public int CodParametro { get; set; }
        public string? DescripcionParametro { get; set; }
        public double? ValorParametro { get; set; }
        public string? Parametro { get; set; }
    }
}
