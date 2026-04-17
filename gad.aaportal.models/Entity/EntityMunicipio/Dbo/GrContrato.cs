using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class GrContrato
    {
        public int CodigoGrContratos { get; set; }
        public string CodEnlaceGrContratos { get; set; } = null!;
        public string? DescripcionGrContratos { get; set; }
        public string? EstadoGrContratos { get; set; }
    }
}
