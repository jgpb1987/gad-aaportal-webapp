using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class DescripcionBloque
    {
        public string CodCatastralPredio { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public string? DescripcionClaseDescripcionEdificacion { get; set; }
        public int NumeroBloquePredio { get; set; }
        public int? EdadConst { get; set; }
        public int? Reparacion { get; set; }
    }
}
