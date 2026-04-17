using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class InfraestrServiciosPredio
    {
        public string CodCatastralPredio { get; set; } = null!;
        public string CodTipoInfraestrServicios { get; set; } = null!;
        public string? InfSePMedidor { get; set; }

        public virtual Predio CodCatastralPredioNavigation { get; set; } = null!;
        public virtual TipoInfraestrServicio CodTipoInfraestrServiciosNavigation { get; set; } = null!;
    }
}
