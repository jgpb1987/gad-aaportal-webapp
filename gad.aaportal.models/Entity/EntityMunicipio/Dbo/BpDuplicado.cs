using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class BpDuplicado
    {
        public string? Cedula { get; set; }
        public int? CodigoIngreso { get; set; }
        public double? Valor { get; set; }
        public string? Nombre { get; set; }
        public string? UserCobro { get; set; }
        public DateTime? FechaI { get; set; }
    }
}
