using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ApParametrosMedicion
    {
        public int CodigoParametro { get; set; }
        public string? NombreParametro { get; set; }
        public string? Unidad { get; set; }
        public string? NormaInenLimite { get; set; }
    }
}
