using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class LocalizacionPredio
    {
        public string CodCatastralPredio { get; set; } = null!;
        public string? LocPrCartaTopografica { get; set; }
        public string? LocPrFotoAerea { get; set; }
        public string? LocPrOtros { get; set; }
        public string? LocPrCoordEste { get; set; }
        public string? LocPrCoordNorte { get; set; }
        public string? LocPrColindNorte { get; set; }
        public string? LocPrColindSur { get; set; }
        public string? LocPrColindEste { get; set; }
        public string? LocPrColindOeste { get; set; }

        public virtual Predio CodCatastralPredioNavigation { get; set; } = null!;
    }
}
