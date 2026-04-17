using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AkmBorrar
    {
        public double? Id { get; set; }
        public string? Numero { get; set; }
        public string? Placas { get; set; }
        public double? KmParaMantenimiento { get; set; }
    }
}
