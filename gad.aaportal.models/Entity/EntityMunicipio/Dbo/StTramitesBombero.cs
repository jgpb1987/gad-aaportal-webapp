using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class StTramitesBombero
    {
        public int NumeroDeTramite { get; set; }
        public string? CedIdentCiudadano { get; set; }
        public string? TipoActividad { get; set; }
        public string? Anio { get; set; }
        public string? Parroquia { get; set; }
        public string? Direccion { get; set; }
        public DateTime? FechaEmision { get; set; }
        public string? ValorPermiso { get; set; }

        public virtual StTramite NumeroDeTramiteNavigation { get; set; } = null!;
    }
}
