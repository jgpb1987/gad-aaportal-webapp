using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VistaColindantesPredio
    {
        public string CodCatastralPredio { get; set; } = null!;
        public string? LocPrCartaTopografica { get; set; }
        public string? LocPrFotoAerea { get; set; }
        public string? LocPrOtros { get; set; }
        public string? LocPrCoordEste { get; set; }
        public string? LocPrCoordNorte { get; set; }
        public string? ColindanteNorte { get; set; }
        public string? ColindanteSur { get; set; }
        public string? ColindanteEste { get; set; }
        public string? ColindanteOeste { get; set; }
    }
}
