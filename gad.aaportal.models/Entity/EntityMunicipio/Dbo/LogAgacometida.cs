using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class LogAgacometida
    {
        public string? CedulaCiudadano { get; set; }
        public string? ApellidosNombres { get; set; }
        public string Sector { get; set; } = null!;
        public string Cuenta { get; set; } = null!;
        public string? NumeroDeMedidor { get; set; }
        public string? Tarifa { get; set; }
        public bool? Alcantarillado { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Usuario { get; set; }
        public int? LecturaActual { get; set; }
        public int? LecturaAnterior { get; set; }
        public string? ClaveCatastral { get; set; }
        public string? RazonModifica { get; set; }
    }
}
