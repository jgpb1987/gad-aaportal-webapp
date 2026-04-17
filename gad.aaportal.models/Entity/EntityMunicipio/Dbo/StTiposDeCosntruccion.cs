using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class StTiposDeCosntruccion
    {
        public StTiposDeCosntruccion()
        {
            StCalculoFondoDeGarantia = new HashSet<StCalculoFondoDeGarantium>();
            StCalculoLegalizacionMulta = new HashSet<StCalculoLegalizacionMulta>();
            StCalculoParaAprobacions = new HashSet<StCalculoParaAprobacion>();
            StCalculoParaLegalizacions = new HashSet<StCalculoParaLegalizacion>();
        }

        public int IdTipoConstruccion { get; set; }
        public string? NombreTipo { get; set; }

        public virtual ICollection<StCalculoFondoDeGarantium> StCalculoFondoDeGarantia { get; set; }
        public virtual ICollection<StCalculoLegalizacionMulta> StCalculoLegalizacionMulta { get; set; }
        public virtual ICollection<StCalculoParaAprobacion> StCalculoParaAprobacions { get; set; }
        public virtual ICollection<StCalculoParaLegalizacion> StCalculoParaLegalizacions { get; set; }
    }
}
