using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class StCalculoLegalizacionMulta
    {
        public double? M2desde { get; set; }
        public double? M2hasta { get; set; }
        public int? ValorConstruccion { get; set; }
        public int? IdTipoConstruccion { get; set; }
        public int IdCalculoLegalizacionMultas { get; set; }

        public virtual StTiposDeCosntruccion? IdTipoConstruccionNavigation { get; set; }
    }
}
