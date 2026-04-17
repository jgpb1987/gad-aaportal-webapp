using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class CondicionesSolarNoEdificado
    {
        public DateTime FechaActual { get; set; }
        public string CodCatastralPredio { get; set; } = null!;
        public int? Aparcamiento { get; set; }
        public int? Agricola { get; set; }
        public int? Desastre { get; set; }
        public DateTime? FechaInicioDesastre { get; set; }
        public DateTime? FechaFinDesastre { get; set; }
        public int? Dominio { get; set; }

        public virtual Predio CodCatastralPredioNavigation { get; set; } = null!;
    }
}
