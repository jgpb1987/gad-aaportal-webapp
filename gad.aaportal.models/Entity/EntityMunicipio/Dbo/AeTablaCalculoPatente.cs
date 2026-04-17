using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AeTablaCalculoPatente
    {
        public int Id { get; set; }
        public double? ValorDesde { get; set; }
        public double? ValorHasta { get; set; }
        public double? FraccionBasica { get; set; }
        public double? FraccionExcedente { get; set; }
    }
}
