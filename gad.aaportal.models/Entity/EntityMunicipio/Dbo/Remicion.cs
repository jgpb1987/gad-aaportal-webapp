using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Remicion
    {
        public int CodIngreso { get; set; }
        public double? InteresAnterior { get; set; }
        public double? InteresNuevo { get; set; }
        public double? RecargoAnterior { get; set; }
        public double? RecargoNuevo { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
