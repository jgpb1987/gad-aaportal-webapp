using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class RtPagoBanco
    {
        public int CodigoPagoBanco { get; set; }
        public int? CodigoDatosIngreso { get; set; }
        public string? ReferenciaPagoBanco { get; set; }
        public string? CodigoBancoPagoBanco { get; set; }
        public string? CodigoCanalPagoBanco { get; set; }
        public string? EstadoPagoBanco { get; set; }

        public virtual DatosIngreso? CodigoDatosIngresoNavigation { get; set; }
    }
}
