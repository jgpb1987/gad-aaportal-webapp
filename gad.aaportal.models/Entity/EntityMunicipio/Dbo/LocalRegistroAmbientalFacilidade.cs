using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class LocalRegistroAmbientalFacilidade
    {
        public int IdFacilidades { get; set; }
        public string? Equipo { get; set; }
        public string? Diametro { get; set; }
        public string? Altura { get; set; }
        public string? PuertoDeMuestreo { get; set; }
        public int? IdLocal { get; set; }
    }
}
