using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class TerceraEdadIngresoManual
    {
        public string CedIdentProp { get; set; } = null!;
        public int? TerEdadProp { get; set; }
        public string? NumeroRegycont { get; set; }
        public string? NombreConyuge { get; set; }
        public string? CedIdentConyuge { get; set; }
        public DateTime? FechaNacConyuge { get; set; }
        public string? AnoSupervivencia { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
