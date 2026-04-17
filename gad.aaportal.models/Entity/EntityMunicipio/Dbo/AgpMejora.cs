using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AgpMejora
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
        public double? Adoquinado { get; set; }
        public double? Aceras { get; set; }
        public double? Alcantarillado { get; set; }
        public double? Agua { get; set; }
        public string? Estado { get; set; }
        public int? IdObraPredio { get; set; }
    }
}
