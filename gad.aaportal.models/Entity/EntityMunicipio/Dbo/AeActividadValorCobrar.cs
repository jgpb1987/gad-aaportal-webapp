using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AeActividadValorCobrar
    {
        public int IdValorCobrar { get; set; }
        public int? CodigoAct { get; set; }
        public double? ValorCobrar { get; set; }
        public string? EstadoTasaAdmin { get; set; }

        public virtual AeActividad? CodigoActNavigation { get; set; }
    }
}
