using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class RteConvenio
    {
        public int CodigoConvenio { get; set; }
        public int? CodigoEspectaculo { get; set; }
        public string? ComentarioConvenio { get; set; }
        public short? PorcentajeConvenio { get; set; }
        public int? Porcentaje { get; set; }
        public string? EstadoConvenio { get; set; }
    }
}
