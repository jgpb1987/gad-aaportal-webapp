using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SmTipoMejora
    {
        public SmTipoMejora()
        {
            SmCostosObras = new HashSet<SmCostosObra>();
            SmMejorasAuxes = new HashSet<SmMejorasAux>();
        }

        public int IdTipoMejora { get; set; }
        public string TipoMejora { get; set; } = null!;

        public virtual ICollection<SmCostosObra> SmCostosObras { get; set; }
        public virtual ICollection<SmMejorasAux> SmMejorasAuxes { get; set; }
    }
}
