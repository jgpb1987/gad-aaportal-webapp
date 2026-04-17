using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class DescripcionVendible
    {
        public int Codigo { get; set; }
        public string CodVendible { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string? Estado { get; set; }
        public double? Valor { get; set; }
    }
}
