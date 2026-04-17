using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class RteNotificacionesDesglose
    {
        public int CodigoNotificacionDesglose { get; set; }
        public int CodIngresoDatosIngreso { get; set; }
        public int? CodigoNotificaciones { get; set; }
        public int? NumeroNotificacionDesglose { get; set; }
        public double? Valor { get; set; }
    }
}
