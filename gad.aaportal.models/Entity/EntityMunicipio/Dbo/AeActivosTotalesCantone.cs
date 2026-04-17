using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AeActivosTotalesCantone
    {
        public int IdCanton { get; set; }
        public string? Canton { get; set; }
        public double? Porcentaje { get; set; }
        public double? Valor { get; set; }
        public int? IdActividadAnual { get; set; }

        public virtual AeActividadAnual? IdActividadAnualNavigation { get; set; }
    }
}
