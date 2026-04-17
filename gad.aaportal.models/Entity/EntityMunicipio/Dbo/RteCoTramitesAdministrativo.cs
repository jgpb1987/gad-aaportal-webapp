using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class RteCoTramitesAdministrativo
    {
        public int CodTramite { get; set; }
        public string? CedIdentCiudadano { get; set; }
        public string? NumeroTramite { get; set; }
        public DateTime? FechaTramite { get; set; }
        public string? Estado { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string? UserIngreso { get; set; }
    }
}
