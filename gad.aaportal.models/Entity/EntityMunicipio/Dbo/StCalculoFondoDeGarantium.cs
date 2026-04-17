using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class StCalculoFondoDeGarantium
    {
        public double? M2desde { get; set; }
        public double? M2hasta { get; set; }
        public int? ValorConstruccion { get; set; }
        public int? IdTipoConstruccion { get; set; }
        public int IdCalculoParaFondoGarantia { get; set; }
        public int? Porcentaje { get; set; }

        public virtual StTiposDeCosntruccion? IdTipoConstruccionNavigation { get; set; }
    }
}
