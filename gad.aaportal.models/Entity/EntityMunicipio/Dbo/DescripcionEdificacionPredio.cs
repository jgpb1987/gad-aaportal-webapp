using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class DescripcionEdificacionPredio
    {
        public string CodCatastralPredio { get; set; } = null!;
        public int BloquePredio { get; set; }
        public string? CodIndiceDescripcionEdificacionCanton1 { get; set; }
        public string? CodIndiceDescripcionEdificacionCantonAux { get; set; }
        public int CodIndiceDescripcionEdificacionCanton { get; set; }

        public virtual Predio CodCatastralPredioNavigation { get; set; } = null!;
        public virtual IndiceDescEdifCanton CodIndiceDescripcionEdificacionCantonNavigation { get; set; } = null!;
    }
}
