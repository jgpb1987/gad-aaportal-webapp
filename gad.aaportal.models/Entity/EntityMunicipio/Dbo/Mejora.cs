using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Mejora
    {
        public string CedIdentCiudadano { get; set; } = null!;
        public DateTime? FechaAemitir { get; set; }
        public double? Valor { get; set; }
        public string? Comentario { get; set; }
        public int? CodigoIngresoArentas { get; set; }
        public string? ClaveCatastral { get; set; }
        public string? CuotaAnio { get; set; }
        public string? CuotaMes { get; set; }
        public string? Obra { get; set; }
        public string? Sector { get; set; }
        public string? Cuenta { get; set; }
        public int Autonumerico { get; set; }

        public virtual Ciudadano CedIdentCiudadanoNavigation { get; set; } = null!;
    }
}
