using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AeDeclaracionPatrimonialCab
    {
        public int IdDeclaracion { get; set; }
        public int? DeclaracionAnual { get; set; }
        public string? CedulaP { get; set; }
        public string? CedulaC { get; set; }
        public string? Aplica { get; set; }
        public string? Observaciones { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string? AnioDeclaracion { get; set; }
    }
}
